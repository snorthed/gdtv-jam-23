using CommonComponents;
using CommonComponents.StateMachine;
using Enemy.States;
using UI;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(SliderDisplay))]
	public class EnemyManager : Damagable
	{
		private readonly StateMachine<EnemyState, EnemyBaseState> _stateMachine;
		private EnemyMover _mover;

		private SliderDisplay _hpBar;

		protected override void Awake()
		{
			base.Awake();
			_hpBar = GetComponent<SliderDisplay>();
			HPChanged += _hpBar.SetValues;

			_mover = GetComponent<EnemyMover>();

			HPEmpty += OnDeath;
		}

		public void SetTarget(Transform newPos)
		{
			_mover.Target = newPos;
		}

		private void OnDeath()
		{
			Destroy(this.gameObject);
		}

	}

}