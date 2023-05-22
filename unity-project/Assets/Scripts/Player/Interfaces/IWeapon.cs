
using UnityEngine;

namespace Player.Interfaces
{
	public interface IWeapon
	{

        float PrimaryCooldown { get; set; }

        void PrimaryAttack(Vector3 fireDirection);
		void SecondaryAttack(Vector3 fireDirection);
	}
}