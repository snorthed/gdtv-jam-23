using UnityEngine;

namespace Enemy.States
{
	public class EnemyAttackState : EnemyBaseState
	{
		public EnemyAttackState(GameObject obj, EnemyState state = EnemyState.Attack) : base(obj, state)
		{
		}

		public override EnemyState Tick()
		{
			return State;
		}
	}
}