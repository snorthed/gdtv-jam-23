using Player.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
	public class PlayerWeapon : MonoBehaviour
	{
		[SerializeField] private GameObject primaryShot;


		public void PrimaryAttack(Vector3 fireDirection)
		{
			var newShot = Instantiate(this.primaryShot, transform.position, Quaternion.identity);
			newShot.GetComponent<Lazor>().Fire(fireDirection.normalized);
		}

        public void SecondaryAttack(Vector3 fireDirection) { throw new System.NotImplementedException(); }
	}
}