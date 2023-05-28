using System;
using CommonComponents;
using CommonComponents.Interfaces;
using UnityEngine;

namespace Environment
{
	public class HackingConsole : Interactable
	{
		public bool ActiveState { get; set; }

		private event Action OnActivate;

		public override void Action(InteractableActor actor)
		{
			ActiveState = true;
			OnActivate?.Invoke();
		}

		public void Subscribe(Action act) => OnActivate += act;
	}
}