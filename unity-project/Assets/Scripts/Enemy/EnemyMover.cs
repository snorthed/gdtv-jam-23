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
		protected NavMeshAgent _navMeshAgent;
		[SerializeField] protected float targetPositionUpdateFrequency = 2.0f;
		public Transform Target
		{
			get => target;
			set
			{
				target = value;
				hasTarget = target != null;
			}
		}

		public Vector3 WalkPosition { get; set; }

		protected float _moveAdjustmentTimer = 2.0f;

		[SerializeField] private Transform target;
		protected bool hasTarget;


		protected virtual void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_moveAdjustmentTimer = targetPositionUpdateFrequency;
		}
		
		// Update is called once per frame
		protected virtual void Update()
		{
			_moveAdjustmentTimer -= Time.deltaTime;
			if (_moveAdjustmentTimer < 0f && hasTarget && target.gameObject.activeInHierarchy)
			{
				SetNavDestination(target.position);
			}
		}

		protected void SetNavDestination(Vector3 targetPosition)
		{
			_navMeshAgent.SetDestination(targetPosition);
			_moveAdjustmentTimer = targetPositionUpdateFrequency;
		}
	}
}
