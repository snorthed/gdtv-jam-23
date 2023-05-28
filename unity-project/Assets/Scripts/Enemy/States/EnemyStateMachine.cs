using System;
using CommonComponents.StateMachine;
using Player;
using UnityEngine;

namespace Enemy.States
{
	public enum EnemyState
	{
		Idle,
		Wandering,
		Alert,
		Seeking,
		Attack,
		Dead,
	}

    public class EnemyStateMachine : StateMachine<EnemyState, EnemyBaseState>
	{
		private EnemyStateContext _context;
        protected EnemyBaseState GetCurrentState => CurrentState as EnemyBaseState;


		protected override void Awake()
		{
			_context = new EnemyStateContext()
			{
				
						   EnemyManager = GetComponent<EnemyManager>(),
						   PlayerCache = SingletonRepo.PlayerObject,
						   Mover = GetComponent<EnemyMover>(),
						   animator = GetComponent<Animator>(),
			};
			base.Awake();
		}

		protected void Start()
		{
			_context.PlayerCache = SingletonRepo.PlayerObject;
		}

		public override bool AddState(EnemyBaseState newState)
		{
			var result = base.AddState(newState);
			newState.SetContext(_context);
			return result;

		}

		protected override EnemyBaseState SwapState(EnemyState newStateEnum)
		{
			var oldState = GetCurrentState;
			oldState?.Deactivate();

			var newState = StateDictionary[newStateEnum];
			newState.SetContext(_context);
			newState.Activate();
			CurrentState = newState;
			return newState;
		}

		
		public void DamageTaken(float amount)
		{
			var newStateEnum = GetCurrentState.DamageTaken(amount);
			TrySwapState(newStateEnum);
		}
	}
}