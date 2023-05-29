using UnityEngine;

namespace Enemy.States
{
	public class EnemyAlertState : EnemyBaseState
	{
		public EnemyAlertState(GameObject obj, EnemyState state = EnemyState.Alert) : base(obj, state)
		{
		}

		public override EnemyState Tick()
		{
			return State;
		}

		public override void Activate()
		{

		}

		public override void Deactivate() {}
	}
}