using CommonComponents.Interfaces;
using System.Collections;
using UnityEngine;

namespace Player.Weapons
{
	public class Melee : BaseWeapon  
	{
		private Coroutine _punching;

		public override void BeginPrimaryAttack(Vector3 fireDirection)
		{
			Debug.Log("Start Firing");
			FireDirection = fireDirection;
			_punching = StartCoroutine(PunchingRepeater());
		}

		private IEnumerator PunchingRepeater()
		{
			while (true)
			{
				Collider[] _enemyColliders = Physics.OverlapSphere(weaponsSetup._PrimaryProjectile.transform.position, weaponsSetup._PrimaryRange);
				for (int i =0; i<_enemyColliders.Length; i++)
                {
					//enemyTakeDamage or Send hit?
                }
				
				yield return new WaitForSeconds(weaponsSetup._PrimaryCooldown);
			}
		}
		
		public override void SecondaryAttack(Vector3 fireDirection)
		{
			throw new System.NotImplementedException();
		}

    
	}
}
