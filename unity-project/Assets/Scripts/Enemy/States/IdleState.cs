using System;
using CommonComponents.StateMachine;
using Helpers;
using UnityEngine;

namespace Enemy.States
{
    public class EnemyIdleState : BaseState<EnemyState>
    {
		public EnemyIdleState(GameObject obj, EnemyState state = EnemyState.Idle) : base(obj, state)
		{

		}

        public override EnemyState Tick()
		{
			//_gameObject.CanSeeTarget();
			return EnemyState.Idle;
		}

	}
}