
using System;
using Player.Weapons;
using UnityEngine;

namespace CommonComponents.Interfaces
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		public Vector3 FireDirection { get; set; }

        [SerializeField] protected WeaponsSetup weaponsSetup;

		protected ObjectCachePool<Lazor> PrimaryShotPool;
		protected ObjectCachePool<Lazor> SecondaryShotPool;

		public void Awake()
		{
			PrimaryShotPool = new ObjectCachePool<Lazor>(weaponsSetup.primary.projectile, 30);
		}

		private void OnDestroy()
		{
			PrimaryShotPool.Destroy();
		}

		public abstract void BeginPrimaryAttack(Vector3 fireDirection);
		public abstract void SecondaryAttack(Vector3 fireDirection);
		public virtual void CancelPrimaryAttack(Vector3 lookDir) { }

		public Lazor GetNextBullet(WeaponMode mode)
		{
			var shot = PrimaryShotPool.PullObject();
			shot.Initialize(transform.position, mode.speed, mode.range, mode.damage);
			return shot;
		}
	}
}