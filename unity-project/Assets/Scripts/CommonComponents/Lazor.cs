using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public class Lazor : PooledObject, IDamageDealer
	{

		private float _speed;
		private float _timeToLive;
		[field:SerializeField] public float Damage { get; private set; }
		private Vector3 _moveDir;

		public void Initialize(Vector3 startPos, float speed ,float timeToLive,int damage )
		{
			SetStartPoint(startPos);
			_speed = speed;
			_timeToLive = timeToLive;
			Damage = damage;
		}
		public void Fire(Vector3 shootDir)
		{
			_moveDir = shootDir;
		}

		private void Update()
		{
			this.transform.position += (_moveDir * (_speed * Time.deltaTime));
			_timeToLive -= Time.deltaTime;
			if (_timeToLive <0f)
			{
				EndBullet();
			}
		}

		private void EndBullet() { ReturnToPool(); }

		private void OnCollisionEnter(Collision other) => EndBullet();
		private void OnTriggerEnter(Collider other) => EndBullet();
	}
}
