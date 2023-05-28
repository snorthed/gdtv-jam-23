using Player;
using UnityEngine;
namespace Enemy
{
	public class EnemyStateContext
	{
		
		public Animator animator { get; set; }
		public PlayerController PlayerCache { get; set; }
		public EnemyManager EnemyManager { get; set; }

		public EnemyMover Mover { get; set; }
	}
}