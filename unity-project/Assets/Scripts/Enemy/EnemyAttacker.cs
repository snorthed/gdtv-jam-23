using CommonComponents;
using Player.Weapons;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : EnemyMover
	{
		[SerializeField] private WeaponMode weaponSetup;
		[SerializeField] private float takeShotRange;
		Animator animator;
		[SerializeField] private bool StopMovingAtRange;
		[SerializeField] private bool FireIfNotInRange;

		private float _shotCooldown;

		private ObjectCachePool<Projectile> _bulletPool;

		protected override void Awake()
		{
			base.Awake();

			_bulletPool = new ObjectCachePool<Projectile>(weaponSetup.projectile, 5);
		}


		protected override void Update()
		{
			_moveAdjustmentTimer -= Time.deltaTime;
			_shotCooldown -= Time.deltaTime;
			if (!hasTarget || Target == null || !Target.gameObject.activeInHierarchy) return;

			bool inRange = Vector3.Distance(transform.position, Target.position) < takeShotRange;

			if (_shotCooldown < 0f && (inRange || FireIfNotInRange))
			{
				var bullet = _bulletPool.PullObject();
				var position = transform.position;
				bullet.Initialize(position, weaponSetup.speed, weaponSetup.timeToLive, weaponSetup.damage);
				animator = GetComponent<EnemyManager>().enemyAnimator;
				animator.SetTrigger("isShooting");
				bullet.Fire((Target.position - position).normalized);
				_shotCooldown = weaponSetup.cooldown;
			}

			if (_moveAdjustmentTimer < 0f && (!inRange || !StopMovingAtRange) )
			{
				var test = Vector3.ClampMagnitude(transform.position - Target.position, takeShotRange);
				SetNavDestination(transform.position - test);
			}

			
		}
	}
}