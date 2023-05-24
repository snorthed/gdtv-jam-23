using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Weapons
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponSetup", order = 2)]
	public class WeaponsSetup : ScriptableObject
	{
		public GameObject weaponModel;
		public WeaponMode primary;
        public WeaponMode secondary;

	}
}
