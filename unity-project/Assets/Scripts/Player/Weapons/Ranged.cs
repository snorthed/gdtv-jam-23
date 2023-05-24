using System.Collections;
using CommonComponents;
using CommonComponents.Interfaces;
using UnityEngine;

namespace Player.Weapons
{
	public class Ranged : BaseWeapon
	{
		private Coroutine _firing;


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

		public override void SecondaryAttack(Vector3 fireDirection)
		{
		}
	}
}
