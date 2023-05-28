using System;
using CommonComponents.Interfaces;

namespace Management
{
	public class GameStateManager
	{
		private static readonly Lazy<GameStateManager> LazyManager = new Lazy<GameStateManager>();
		public static GameStateManager Instance => LazyManager.Value;
		private event GameStateChange StateChangeEvent;

		public GameState CurrentState { get; private set; } = GameState.Running;

		public void SetState(GameState state)
		{
			CurrentState = state;
			StateChangeEvent?.Invoke(state);
		}

		public void Subscribe(IGameStateSubscriber sub) => StateChangeEvent += sub.OnStateChange;


	}
}