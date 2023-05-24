using CommonComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Weapons
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponMode", order = 1)]

	public class WeaponMode : ScriptableObject
	{
		public int damage;
		public float range;
		public float speed;
		public float cooldown;
		public Lazor projectile;
	}
}