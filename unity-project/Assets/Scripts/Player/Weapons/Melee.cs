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
				var setup = weaponsSetup.primary;
				var primaryAttackCheck = Instantiate(setup.projectile,this.transform);
				primaryAttackCheck.transform.position = (transform.position+transform.forward*setup.range);
				primaryAttackCheck.GetComponent<SphereCollider>().radius = setup.range;
				Destroy(primaryAttackCheck,setup.speed);
				
				yield return new WaitForSeconds(setup.cooldown);
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
				var setup = weaponsSetup.secondary;

				var _secondaryAttackCheck = Instantiate(setup.projectile, this.transform);
				
				_secondaryAttackCheck.transform.position = (transform.position + transform.forward * setup.range);
				_secondaryAttackCheck.GetComponent<SphereCollider>().radius = setup.range;
				_secondaryAttackCheck.GetComponent<ParticleSystem>().Play();
				//var explosionPrefab = Instantiate(_explosionVFXPrefab);
				//explosionPrefab.transform.position = _secondaryAttackCheck.transform.position;
				Destroy(_secondaryAttackCheck, setup.speed);

				yield return new WaitForSeconds(setup.cooldown);
			}
		}

	}
}
