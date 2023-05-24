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
		private PlayerController _playerCache;

		protected override void Awake()
		{
			_playerCache = SingletonRepo.PlayerObject;
			base.Awake();
		}

		protected override EnemyBaseState SwapState(EnemyState newStateEnum)
		{
			var newState = base.SwapState(newStateEnum);
			newState.PlayerRef = _playerCache;
			return newState;
		}
	}
}