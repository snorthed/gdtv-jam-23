using CommonComponents.StateMachine;
using Player;
using UnityEngine;

namespace Enemy.States
{
	public abstract class EnemyBaseState : BaseState<EnemyState>
	{
		public PlayerController PlayerRef { get; set; }
		protected EnemyBaseState(GameObject obj, EnemyState state) : base(obj, state)
		{

		}
	}
}