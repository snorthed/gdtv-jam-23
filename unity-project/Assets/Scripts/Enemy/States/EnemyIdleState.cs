using System;
using CommonComponents.StateMachine;
using Helpers;
using UnityEngine;

namespace Enemy.States
{
    public class EnemyIdleState : EnemyBaseState
    {
		public EnemyIdleState(GameObject obj, EnemyState state = EnemyState.Idle) : base(obj, state)
		{

		}

        public override EnemyState Tick()
		{
			
			var canSeePlayer = _gameObject.CanSeeTarget(PlayerRef.gameObject, 30f, 30f, LayerMask.GetMask("Player", "Terrain", "PlayerBullets"), PlayerRef.GetType());
			
			return canSeePlayer ? EnemyState.Alert : EnemyState.Idle;
		}

	}
}