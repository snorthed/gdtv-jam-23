using System.Collections;
using CommonComponents;
using Enemy;
using UnityEngine;

public class EnemySpawner : Damagable
{
	[SerializeField] private EnemyManager spawnObject;
	[SerializeField] private Transform spawnPoint;

	[SerializeField]private int spawnNumber = -1;
	[SerializeField]private float spawnDelay;

	private bool _isSpawning = false;

	private Transform _attackTarget;

	protected override void Awake()
	{
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}

		HPEmpty += OnHPEmpty;

		base.Awake();
	}

    private void OnHPEmpty(Damagable damagable) => Destroy(this.gameObject);

    private void Start()
	{
		StartSpawn();
		_attackTarget = SingletonRepo.PlayerObject.transform;

	}
	
	public void StartSpawn() => StartSpawn(spawnNumber == -1 ? null : spawnNumber, spawnDelay);

	public void StartSpawn(int? num, float delay)
	{
		if (!_isSpawning)
		{
			StartCoroutine(DoSpawn(num, delay));
		}
	}

	public void StopSpawn() => _isSpawning = false;

	// ReSharper disable Unity.PerformanceAnalysis
	private IEnumerator DoSpawn(int? number, float delay)
	{
		_isSpawning = true;
		while (_isSpawning && (!number.HasValue || number.Value > 0))
		{
			yield return new WaitForSeconds(delay);

			var newEnemy = Instantiate<EnemyManager>(spawnObject, spawnPoint.position, Quaternion.identity);
			newEnemy.SetTarget(_attackTarget);
			if(number.HasValue) number--;
		}
		_isSpawning = false;
	}
}