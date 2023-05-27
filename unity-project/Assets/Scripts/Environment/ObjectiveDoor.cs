using System;
using System.Collections.Generic;
using System.Linq;
using CommonComponents;
using UnityEngine;

namespace Environment
{
	public class ObjectiveDoor : MonoBehaviour
	{
		[SerializeField] private List<HackingConsole> keys;
		[SerializeField] private List<Damagable> keyEnemies;
		[SerializeField] private bool requireAllConditions;
		private bool _locked;

		private void Start()
		{
			foreach (var interactable in keys)
			{
				interactable.Subscribe(OnKeyChange);
			}

			foreach (var enemy in keyEnemies)
			{
				enemy.HPEmpty += OnKeyChange;
			}
		}

		private void OnKeyChange()
		{
			if (keys.Count > 0 )
			{
				_locked |= keys.Any(console => !console.ActiveState);
			}
			
			if(keyEnemies.Count > 0 && (requireAllConditions || keys.Count == 0) )
			{
				_locked |= keyEnemies.Any(d => d.CurrentHP < 0);
			}

			if (!_locked)
			{
				this.gameObject.SetActive(false);
			}
		}
	}
}