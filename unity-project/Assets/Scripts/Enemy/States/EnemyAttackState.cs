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

		public override void Activate()
		{
			Context.animator.SetBool("isRunning",true);
			Context.Mover.Target = Context.PlayerCache.transform;
		}

		public override void Deactivate()
		{
			Context.animator.SetBool("isRunning", false);
			Context.Mover.Target = null;
		}
	}
}