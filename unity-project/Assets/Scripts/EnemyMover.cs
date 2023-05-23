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

	[SerializeField] float _timer = 2.0f;

	[SerializeField] private GameObject _bullet;

	// Update is called once per frame
    void Update()
	{
		_timer -=Time.deltaTime;
		if (_timer < 0f)
		{
			var position = target.position;
			_navMeshAgent.SetDestination(position);
			_timer = 2.0f;

			var myPos = transform.position;
			var newShot = Instantiate(_bullet, myPos, Quaternion.identity);

            var lazer = newShot.GetComponent<Lazor>();
			lazer.Initialize(5, 5, 5);
			lazer.Fire((position - myPos).normalized);
        }
    }
}
