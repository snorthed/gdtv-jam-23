using System;
using System.Collections;
using Enemy;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private EnemyManager spawnObject;
	[SerializeField] private Transform spawnPoint;

	[SerializeField]private int spawnNumber = -1;
	[SerializeField]private float spawnDelay;

	private bool _isSpawning = false;

	private Transform _attackTarget;

	private void Awake()
	{
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}

	}

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

	private IEnumerator DoSpawn(int? number, float delay)
	{
		_isSpawning = true;
		while (_isSpawning && (!number.HasValue || number.Value <= 0))
		{
			yield return new WaitForSeconds(delay);

			var newEnemy = Instantiate<EnemyManager>(spawnObject, spawnPoint.position, Quaternion.identity);
			newEnemy.SetTarget(_attackTarget);
			number--;
		}

		_isSpawning = false;
	}
}