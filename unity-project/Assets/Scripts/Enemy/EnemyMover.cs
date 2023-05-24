using System;
using CommonComponents;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Enemy
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class EnemyMover : MonoBehaviour
	{
		private NavMeshAgent _navMeshAgent;

		public Transform Target { get => target; set => target = value; }

		[SerializeField] float timer = 2.0f;

		[SerializeField] private Projectile bullet;
		[SerializeField] private Transform target;
		private ObjectCachePool<Projectile> _lazerPool;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_lazerPool = new ObjectCachePool<Projectile>(bullet, 5);
		}
		
		// Update is called once per frame
		void Update()
		{
			timer -= Time.deltaTime;
			if (timer < 0f)
			{
				var position = Target.position;
				_navMeshAgent.SetDestination(position);
				timer = 2.0f;

				var myPos = transform.position;
				var shot = _lazerPool.PullObject();
				shot.Initialize(transform.position, 10, 10, 5);
				shot.Fire((position - myPos).normalized);
			}
		}

		private void OnDestroy()
		{
			_lazerPool.Destroy();
		}
	}
}
