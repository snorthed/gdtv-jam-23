using CommonComponents.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace CommonComponents
{
	public class Grenade : Projectile
	{

		[SerializeField] GameObject explosion;
		
		
		public override void Update()
		{
			_timeToLive -= Time.deltaTime;
			
			if (_timeToLive <0f)
			{
				StartCoroutine(Explode());
			}
		}

        private IEnumerator Explode()
        {
			Instantiate(explosion);
			yield return new WaitForSeconds(_speed);
			EndBullet();
        }


		public override void OnCollisionEnter(Collision other)
		{

		}
		public override void OnTriggerEnter(Collider other)
        {

        }
	}
}
