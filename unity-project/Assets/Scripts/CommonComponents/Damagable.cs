using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public delegate void DamageTaken(float amount);
	public class Damagable : MonoBehaviour
	{
		public event DamageTaken DamageTaken;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<IDamageDealer>(out var damage))
			{
				DamageTaken?.Invoke(damage.Damage);
			}
		}
	}
}