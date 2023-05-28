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
				var primaryAttackCheck = GetNextBullet(setup,PrimaryShotPool);
				primaryAttackCheck.Initialize(transform.position + transform.forward * setup.range, setup.range, setup.speed, setup.damage);
				primaryAttackCheck.GetComponent<SphereCollider>().radius = setup.range;
				
				
				yield return new WaitForSeconds(setup.cooldown);
			}
		}
		
		public override void BeginSecondaryAttack(Vector3 fireDirection,bool holding)
		{
			Debug.Log("Start Smashing");
			FireDirection = fireDirection;
			_smashing = StartCoroutine(SmashingRepeater(holding));
		}
		public override void CancelSecondaryAttack(Vector3 lookDir)
		{
			StopCoroutine(_smashing);
			var setup = weaponsSetup.secondary;
			var _secondaryAttackCheck = GetNextBullet(setup, SecondaryShotPool);
			_secondaryAttackCheck.Initialize(transform.position + transform.forward * setup.range, setup.range, setup.speed, setup.damage);
			_secondaryAttackCheck.GetComponent<SphereCollider>().radius = setup.range;
			_secondaryAttackCheck.GetComponent<ParticleSystem>().Play();

		}

		private IEnumerator SmashingRepeater(bool holding)
		{
			
			while (holding)
			{

				
				//var explosionPrefab = Instantiate(_explosionVFXPrefab);
				//explosionPrefab.transform.position = _secondaryAttackCheck.transform.position;
				

				yield return new WaitForEndOfFrame();
			}
		}

	}
}
