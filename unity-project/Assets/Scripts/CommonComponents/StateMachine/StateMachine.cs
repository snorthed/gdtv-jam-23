using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonComponents.StateMachine
{
	public abstract class StateMachine<E, T> : MonoBehaviour where E : Enum 
																where T : BaseState<E>
	{
		private Dictionary<E, T> _stateDictionary;
		private BaseState<E> _currentState;

		protected virtual void Awake()
		{
			_stateDictionary = new Dictionary<E, T>();
		}

		public bool AddState(T newState)
		{
			return _stateDictionary.TryAdd(newState.State, newState);
		}

		public void Update()
		{
			var newStateEnum = _currentState.Tick();
			if (!newStateEnum.Equals(_currentState.State))
			{
				SwapState(newStateEnum);
			}

		}

		protected virtual T SwapState(E newStateEnum)
		{
			_currentState = _stateDictionary[newStateEnum];
			return (T)_currentState;
		}
	}

}