using UnityEngine;

namespace Enemy.States
{
	public class EnemyDeadState : EnemyBaseState
	{
		public EnemyDeadState(GameObject obj, EnemyState state = EnemyState.Dead) : base(obj, state)
		{
		}

		public override EnemyState Tick()
		{
			return State;
		}

		public override void Activate()
		{
			Context.animator.SetTrigger("isDead");
			Context.Mover.Target = Context.PlayerCache.transform;
		}

		public override void Deactivate()
		{
			Context.Mover.Target = null;
		}
	}
}