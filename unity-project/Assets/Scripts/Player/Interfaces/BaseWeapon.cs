
using UnityEngine;

namespace Player.Interfaces
{
	public abstract class BaseWeapon : MonoBehaviour
	{

		[SerializeField] protected WeaponsSetup weaponsSetup;

        abstract public void PrimaryAttack(Vector3 fireDirection);
		abstract public void SecondaryAttack(Vector3 fireDirection);
	}
}