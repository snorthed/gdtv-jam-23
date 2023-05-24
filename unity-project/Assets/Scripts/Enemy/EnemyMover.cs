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
		[SerializeField] private float targetPositionUpdateFrequency = 2.0f;
		public Transform Target { get => target; set => target = value; }
		public Vector3 WalkPosition { get; set; }

		float _timer = 2.0f;

		[SerializeField] private Projectile bullet;
		[SerializeField] private Transform target;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_timer = targetPositionUpdateFrequency;
		}
		
		// Update is called once per frame
		void Update()
		{
			_timer -= Time.deltaTime;
			if (_timer < 0f && target != null)
			{
				_navMeshAgent.SetDestination(target.position);
			}
		}
	}
}
