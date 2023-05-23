using System;
using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public class HealthPool : MonoBehaviour, IHealth
	{
		public float MaxHP { get; set; }
        public float CurrentHP { get; set; }
		public event HPChanged DamageTaken;
		public event Action HPEmpty;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<IDamageDealer>(out var damage))
			{
				OnDamageTaken(damage.Damage);
			}
		}

		protected virtual void OnDamageTaken(float amount)
		{
			CurrentHP -= amount;
			if (CurrentHP < 0)
			{
				HPEmpty?.Invoke();
			}
			else
			{
				DamageTaken?.Invoke(amount, CurrentHP);
			}
		}
	}
}