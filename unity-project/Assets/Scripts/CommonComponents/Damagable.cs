using System;
using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	public delegate void DamageTaken(float amount);
	public class Damagable : MonoBehaviour, IHealth
	{
		protected virtual void Awake()
		{
			DamageTaken += OnDamageTaken;
		}

		private void OnDamageTaken(float amount)
		{
			CurrentHP -= amount;
			if (CurrentHP > 0.0f)
			{
				HPChanged?.Invoke(amount, CurrentHP);
			}
			else
			{
				HPEmpty?.Invoke();
			}
		}

		public event DamageTaken DamageTaken;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<IDamageDealer>(out var damage))
			{
				DamageTaken?.Invoke(damage.Damage);
			}
		}

		

		[field: SerializeField] public float MaxHP { get; set; }
		[field: SerializeField]public float CurrentHP { get; set; }
		public event HPChanged HPChanged;
		public event Death HPEmpty;
	}
}