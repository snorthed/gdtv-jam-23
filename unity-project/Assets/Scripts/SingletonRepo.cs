using System;
using Player;
using UnityEngine;

public class SingletonRepo
{
	private static readonly Lazy<SingletonRepo> LazyRepo = new Lazy<SingletonRepo>();

	public static SingletonRepo Instance => LazyRepo.Value;

	public static PlayerUIManager PlayerUI
	{
		get
		{
			if (Instance._playerUI == null)
			{
				Instance._playerUI = PlayerUIManager.Instance;
			}

			return Instance._playerUI;
		}
	}

	private PlayerUIManager _playerUI = null;

	public static PlayerController PlayerObject { get; set; }
}

