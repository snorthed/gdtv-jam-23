
using UnityEngine;

namespace Player.Interfaces
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		public Vector3 FireDirection { get; set; }

        [SerializeField] protected WeaponsSetup weaponsSetup;


		public abstract void BeginPrimaryAttack(Vector3 fireDirection);
		public abstract void SecondaryAttack(Vector3 fireDirection);
		public virtual void CancelPrimaryAttack(Vector3 lookDir) { }
	}
}