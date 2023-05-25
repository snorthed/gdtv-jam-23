using System;
using UnityEngine;

namespace CommonComponents.StateMachine
{
	public abstract class BaseState<E>
	{
		protected readonly GameObject _gameObject;
		protected readonly Transform _transform;

        public E State { get; }

        public BaseState(GameObject obj, E state)
		{
			_gameObject = obj.gameObject;
			_transform = obj.transform;
            State = state;
        }

		public abstract E Tick();

		public abstract void Activate();

		public abstract void Deactivate();
	}
}