using CommonComponents.StateMachine;

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
        public EnemyBaseState GetCurrentState => CurrentState as EnemyBaseState;


		protected void Start()
		{
			_context = new EnemyStateContext()
					   {
				
						   EnemyManager = GetComponent<EnemyManager>(),
						   PlayerCache = SingletonRepo.PlayerObject,
						   Attacker = GetComponent<EnemyAttacker>(),
					   };
		}

		public override bool AddState(EnemyBaseState newState)
		{
			var result = base.AddState(newState);
			newState.SetContext(_context);
			return result;

		}

		public override EnemyBaseState SwapState(EnemyState newStateEnum)
		{
			var oldState = GetCurrentState;
			oldState?.Deactivate();

			var newState = StateDictionary[newStateEnum];
			CurrentState = newState;

			_context.PlayerCache = SingletonRepo.PlayerObject;
			newState.SetContext(_context);
			newState.Activate();
			return newState;
		}

		public override EnemyBaseState TrySwapState(EnemyState newStateEnum)
		{
			return (EnemyBaseState)(CurrentState.State == EnemyState.Dead ? CurrentState : base.TrySwapState(newStateEnum));
		}

		public void DamageTaken(float amount)
		{
			var newStateEnum = GetCurrentState.DamageTaken(amount);
			TrySwapState(newStateEnum);
		}
	}
}