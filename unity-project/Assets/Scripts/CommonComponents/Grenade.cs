using System.Collections;
using UnityEngine;

namespace CommonComponents
{
	public class Grenade : Projectile 
	{

		[SerializeField] GameObject explosion;
		bool isCoroutineStarted;
		private Coroutine _co = null;

		private void Start()
        {
			isCoroutineStarted = false;
        }
        public override void Update()
		{
			
			_timeToLive -= Time.deltaTime;
			Debug.Log(_timeToLive);
			if (_timeToLive<0)
            {
				_timeToLive = 0;
            }
			if (_timeToLive <= 0f&& !isCoroutineStarted)
			{
				
				_co = StartCoroutine(Explode());
			}
		}

        private IEnumerator Explode()
        {
			isCoroutineStarted = true;
			Instantiate(explosion,this.transform.position,Quaternion.identity);
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
