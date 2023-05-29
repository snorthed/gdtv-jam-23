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
			var canSeePlayer = _gameObject.CanSeeTarget(Context.PlayerCache.gameObject,
														30f,
														30f,
														LayerMask.GetMask("Player", "Terrain", "PlayerBullets"),
														Context.PlayerCache.GetType(),
														true);

			return canSeePlayer ? EnemyState.Attack : EnemyState.Idle;
		}

		public override void Activate()
		{
			
			Context.Mover.Target = null;
		}

		public override void Deactivate() {}

		public override EnemyState DamageTaken(float amount) => EnemyState.Attack;
    }
}