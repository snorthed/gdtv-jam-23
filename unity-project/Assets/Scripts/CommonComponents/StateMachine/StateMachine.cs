using System;
using System.Collections.Generic;
using Enemy.States;
using UnityEngine;

namespace CommonComponents.StateMachine
{
	public abstract class StateMachine<E, T> : MonoBehaviour where E : Enum 
																where T : BaseState<E>
	{
		protected Dictionary<E, T> _stateDictionary;
		protected BaseState<E> CurrentState;

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
			var newStateEnum = CurrentState.Tick();
			if (!newStateEnum.Equals(CurrentState.State))
			{
				TrySwapState(newStateEnum);
			}

		}
		protected virtual T TrySwapState(E newStateEnum)
		{
			if (!newStateEnum.Equals(CurrentState.State))
			{
				return SwapState(newStateEnum);
			}
			return (T)CurrentState;

		}

		protected virtual T SwapState(E newStateEnum)
		{
			CurrentState.Deactivate();
			CurrentState = _stateDictionary[newStateEnum];
			CurrentState.Activate();
			return (T)CurrentState;
		}

	}

}