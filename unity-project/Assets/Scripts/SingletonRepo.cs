using System;
using Player;
using UnityEngine;

public class SingletonRepo
{
	private static readonly Lazy<SingletonRepo> LazyRepo = new Lazy<SingletonRepo>();

	public static SingletonRepo Instance => LazyRepo.Value;

	public PlayerUIManager PlayerUI
	{
		get
		{
			if (_playerUI == null)
			{
				_playerUI = PlayerUIManager.Instance;
			}

			return _playerUI;
		}
	}

	private PlayerUIManager _playerUI = null;

	public PlayerController PlayerObject { get; set; }
}

