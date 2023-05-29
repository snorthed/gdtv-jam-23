using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class EnemyMover : MonoBehaviour
	{
		protected NavMeshAgent _navMeshAgent;
		[SerializeField] protected Transform lookTarget;
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

		public bool MoveToTarget { get; set; } = true;

		protected float _moveAdjustmentTimer = 2.0f;

		[SerializeField] private Transform target;
		protected bool hasTarget;
		public bool moveTo { get; set; } = true;



		protected virtual void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_moveAdjustmentTimer = targetPositionUpdateFrequency;
		}
		
		// Update is called once per frame
		protected virtual void Update()
		{
			_moveAdjustmentTimer -= Time.deltaTime;

			if (target != null && target.gameObject.activeInHierarchy)
			{
				this.transform.rotation = Quaternion.LookRotation(target.position - this.transform.position);


				if (_moveAdjustmentTimer < 0f && moveTo )
				{
					SetNavDestination(target.position);
				}
			}

		}

		protected void SetNavDestination(Vector3 targetPosition)
		{
			_navMeshAgent.SetDestination(targetPosition);
			_moveAdjustmentTimer = targetPositionUpdateFrequency;
		}

		public void StopMoving()
        {
			_navMeshAgent.isStopped= true;
			target = null;
        }
		public void OnEnable()
		{
			_navMeshAgent.enabled = true;
		}

		public void OnDisable()
		{
			_navMeshAgent.enabled = false;
		}

		public void SetPosition(Vector3 position) => SetNavDestination(position);
	}
}
