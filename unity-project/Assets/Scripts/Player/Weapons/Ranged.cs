using System;
using System.Collections;
using CommonComponents;
using CommonComponents.Interfaces;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Player.Weapons
{
	public class Ranged : BaseWeapon
	{
		private Coroutine _firing;
		private Coroutine _throwing;
		public float throwingPower;
		IInputInteraction interaction;
		


		// Start is called before the first frame update
		public override void BeginPrimaryAttack(Vector3 fireDirection)
		{
			Debug.Log("Start Firing");
			FireDirection = fireDirection;
			_firing = StartCoroutine(FiringRepeater());
		}

		public override void CancelPrimaryAttack(Vector3 lookDir)
		{
			StopCoroutine(_firing);

		}

		private IEnumerator FiringRepeater()
		{
			while (true)
			{
				var setup = weaponsSetup.primary;
				var lazer = GetNextBullet(weaponsSetup.primary);

				lazer.Initialize(transform.position, setup.speed, setup.range, setup.damage);

				lazer.Fire(FireDirection.normalized);
				yield return new WaitForSeconds(setup.cooldown);
			}
		}

		public override void BeginSecondaryAttack(Vector3 fireDirection, bool interaction )
		{
			Debug.Log("Charging Throw");
			FireDirection = fireDirection;
			_throwing = StartCoroutine(ThrowingGrenade(interaction));
			
		}
		private IEnumerator ThrowingGrenade(bool holding)
        {
			while (holding)
			{
				throwingPower += Time.deltaTime * weaponsSetup._SecondarySpeed;
				Debug.Log(throwingPower);
				yield return new WaitForEndOfFrame();
			}
			
			Mathf.Clamp(throwingPower,weaponsSetup._PrimaryRange, weaponsSetup._SecondaryRange);
			CancelSecondaryAttack(FireDirection);
        }
        public override void CancelSecondaryAttack(Vector3 lookDir)
        {
            StopCoroutine(_throwing);
			
			var grenade = Instantiate(weaponsSetup._SecondaryProjectile);
			grenade.transform.position = (transform.position + transform.up * throwingPower);
			StartCoroutine(SecondaryAttackCooldown());
		}

        private IEnumerator SecondaryAttackCooldown()
        {
			throwingPower = weaponsSetup._PrimaryRange;
			yield return new WaitForSeconds(weaponsSetup._SecondaryCooldown);
        }
    }
}
