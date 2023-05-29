using System.Collections;
using CommonComponents;
using Enemy.States;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(EnemyStateMachine))]
	public class EnemySpawner : Damagable
	{
		[SerializeField] private EnemyManager spawnObject;
		[SerializeField] private Transform spawnPoint;

		[SerializeField]private int spawnNumber = -1;
		[SerializeField]private float spawnDelay;

		private bool _isSpawning = false;

		private Transform _attackTarget;
		private EnemyStateMachine _stateMachine;

		protected override void Awake()
		{
			if (spawnPoint == null)
			{
				spawnPoint = transform;
			}


			base.Awake();
		}

		private void OnHPEmpty(Damagable damagable) => Destroy(this.gameObject);

		private void Start()
		{
			_stateMachine = GetComponent<EnemyStateMachine>();
			_stateMachine.AddState(new SpawnerIdleState(this.gameObject));
			_stateMachine.AddState(new SpawnerAlertState(this.gameObject));
			_stateMachine.AddState(new SpawnerAttackState(this.gameObject));
			HPEmpty += OnHPEmpty;
			DamageTaken += _stateMachine.DamageTaken;

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
			yield return new WaitForSeconds(delay/2);

			while (_isSpawning && (!number.HasValue || number.Value > 0))
			{
				var newEnemy = Instantiate<EnemyManager>(spawnObject, spawnPoint.position, Quaternion.identity);
				newEnemy.ImmediateAttack(_attackTarget);
				if(number.HasValue) number--;
				yield return new WaitForSeconds(delay);

			}
			_isSpawning = false;
		}
	}
}