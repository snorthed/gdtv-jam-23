using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public class Lazor : MonoBehaviour, IDamageDealer
	{

		private float _speed;
		private float _timeToLive;
		public int Damage { get; private set; }
		private Vector3 _moveDir;

		public void Initialize(float speed ,float timeToLive,int damage )
		{
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
				Destroy(this.gameObject);
			}
		}

		private void OnCollisionEnter(Collision other) => Destroy(this.gameObject);
		private void OnTriggerEnter(Collider other) => Destroy(this.gameObject);
	}
}
