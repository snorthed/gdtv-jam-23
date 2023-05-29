using CommonComponents.StateMachine;
using UnityEngine;

namespace Enemy.States
{
	public abstract class EnemyBaseState : BaseState<EnemyState>
	{
		protected EnemyStateContext Context;
		protected EnemyBaseState(GameObject obj, EnemyState state) : base(obj, state)
		{

		}

		public virtual EnemyState DamageTaken(float amount) => State;
		public void SetContext(EnemyStateContext context) => Context = context;
	}
}