using Player;
using UnityEngine;
namespace Enemy
{
	public class EnemyStateContext
	{

		public Animator animator => EnemyManager.enemyAnimator;
		public PlayerController PlayerCache { get; set; }
		public EnemyManager EnemyManager { get; set; }

		public EnemyAttacker Attacker { get; set; }
	}
}
