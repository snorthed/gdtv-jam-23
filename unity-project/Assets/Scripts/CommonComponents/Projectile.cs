using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public class Projectile : PooledObject
	{

		 protected float _speed;
		 protected float _timeToLive;
		[field:SerializeField] public float Damage { get; private set; }
		protected Vector3 _moveDir;

		public virtual void Initialize(Vector3 startPos, float speed ,float timeToLive,int damage )
		{
			SetStartPoint(startPos);
			_speed = speed;
			_timeToLive = timeToLive;
			Damage = damage;
		}
		public virtual void Fire(Vector3 shootDir)
		{
			_moveDir = shootDir;
		}

		public virtual void Update()
		{
			
			this.transform.position += (_moveDir * (_speed * Time.deltaTime));
			_timeToLive -= Time.deltaTime;
			if (_timeToLive <0f)
			{
				EndBullet();
			}
		}


		public void EndBullet() { ReturnToPool(); }

		public virtual void OnCollisionEnter(Collision other) => EndBullet();
		public virtual void OnTriggerEnter(Collider other) => EndBullet();
	}
}
