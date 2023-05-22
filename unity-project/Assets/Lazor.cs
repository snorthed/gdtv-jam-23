using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazor : MonoBehaviour
{

	[SerializeField] private float speed = 6.0f;
	private Vector3 _moveDir;


	public void Fire(Vector3 shootDir)
	{
		_moveDir = shootDir;
	}

	private void Update()
	{
		this.transform.position += (_moveDir * (speed * Time.deltaTime));
	}
}
