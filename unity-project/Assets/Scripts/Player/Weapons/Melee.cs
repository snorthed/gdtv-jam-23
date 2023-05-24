using CommonComponents.Interfaces;
using System.Collections;
using UnityEngine;

namespace Player.Weapons
{
	public class Melee : BaseWeapon  
	{
		private Coroutine _punching;
		private Coroutine _smashing;
		[SerializeField] GameObject player;
		
		public override void BeginPrimaryAttack(Vector3 fireDirection)
		{
			Debug.Log("Start punching");
			FireDirection = fireDirection;
			_punching = StartCoroutine(PunchingRepeater());
		}
		public override void CancelPrimaryAttack(Vector3 lookDir)
		{
			StopCoroutine(_punching);

		}
		private IEnumerator PunchingRepeater()
		{
			while (true)
			{
				var primaryAttackCheck = Instantiate(weaponsSetup._PrimaryProjectile,this.transform);
				primaryAttackCheck.transform.position = (transform.position+transform.forward*weaponsSetup._PrimaryRange);
				primaryAttackCheck.GetComponent<SphereCollider>().radius = weaponsSetup._PrimaryRange;
				Destroy(primaryAttackCheck,weaponsSetup._PrimarySpeed);
				
				yield return new WaitForSeconds(weaponsSetup._PrimaryCooldown);
			}
		}
		
		public override void BeginSecondaryAttack(Vector3 fireDirection,bool holding)
		{
			Debug.Log("Start Smashing");
			FireDirection = fireDirection;
			_smashing = StartCoroutine(SmashingRepeater());
		}
		public override void CancelSecondaryAttack(Vector3 lookDir)
		{
			StopCoroutine(_smashing);

		}

		private IEnumerator SmashingRepeater()
		{
			while (true)
			{
				var _secondaryAttackCheck = Instantiate(weaponsSetup._SecondaryProjectile, this.transform);
				
				_secondaryAttackCheck.transform.position = (transform.position + transform.forward * weaponsSetup._SecondaryRange);
				_secondaryAttackCheck.GetComponent<SphereCollider>().radius = weaponsSetup._SecondaryRange;
				_secondaryAttackCheck.GetComponent<ParticleSystem>().Play();
				//var explosionPrefab = Instantiate(_explosionVFXPrefab);
				//explosionPrefab.transform.position = _secondaryAttackCheck.transform.position;
				Destroy(_secondaryAttackCheck, weaponsSetup._SecondarySpeed);

				yield return new WaitForSeconds(weaponsSetup._SecondaryCooldown);
			}
		}

	}
}
