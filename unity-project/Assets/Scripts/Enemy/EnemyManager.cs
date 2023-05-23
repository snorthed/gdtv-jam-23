using System;
using CommonComponents;
using CommonComponents.Interfaces;
using Environment;
using UI;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(EnemyMover))]
	[RequireComponent(typeof(Damagable))]
	[RequireComponent(typeof(SliderDisplay))]
	public class EnemyManager : MonoBehaviour, IHealth
	{
		private Damagable _damageDection;
		private EnemyMover _mover;
		private SliderDisplay _hpBar;

		[field:SerializeField] public float MaxHP { get; private set; }
		[field:SerializeField] public float CurrentHP { get; private set; }


		private void Awake()
		{
			_hpBar = GetComponent<SliderDisplay>();
			HPChanged += _hpBar.SetValues;

			_mover = GetComponent<EnemyMover>();
			_damageDection = GetComponent<Damagable>();
			_damageDection.DamageTaken += OnDamageTaken;

			HPEmpty += OnDeath;
		}

		private void OnDeath()
		{
			Destroy(this.gameObject);
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

		public event HPChanged HPChanged;
		public event Death HPEmpty;
	}
}