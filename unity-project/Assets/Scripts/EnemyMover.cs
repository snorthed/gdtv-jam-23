using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
	private NavMeshAgent _navMeshAgent;

	[SerializeField] private Transform target;

	private void Awake()
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	private float _timer = 2.0f;
    // Update is called once per frame
    void Update()
	{
		_timer = -Time.deltaTime;
		if (_timer < 0f)
		{
			_navMeshAgent.SetDestination(target.position);
		}
	}
}
