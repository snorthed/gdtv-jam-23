using Player;

namespace Enemy
{
	public class EnemyStateContext
	{
		public PlayerController PlayerCache { get; set; }
		public EnemyManager EnemyManager { get; set; }

		public EnemyMover Mover { get; set; }
	}
}