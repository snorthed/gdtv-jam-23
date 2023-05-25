using CommonComponents.StateMachine;
using Player;

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
						   Mover = GetComponent<EnemyMover>()
					   };
			base.Awake();
		}

		protected override EnemyBaseState SwapState(EnemyState newStateEnum)
		{
			var oldState = GetCurrentState;
			oldState.Deactivate();
			var newState = _stateDictionary[newStateEnum];
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