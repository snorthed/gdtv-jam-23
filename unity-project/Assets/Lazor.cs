using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazor : MonoBehaviour
{

	float _Speed;
	float _TimeToLive;
	int _Damage;
	private Vector3 _moveDir;

	public void Initialize(float speed ,float timeToLive,int damage )
    {
		_Speed = speed;
		_TimeToLive = timeToLive;
		_Damage = damage;
    }
	public void Fire(Vector3 shootDir)
	{
		_moveDir = shootDir;
	}

	private void Update()
	{
		this.transform.position += (_moveDir * (_Speed * Time.deltaTime));
		_TimeToLive -= Time.deltaTime;
		if (_TimeToLive <0f)
        {
			Destroy(this.gameObject);
        }
	}

	private void OnCollisionEnter(Collision other) => Destroy(this.gameObject);
	private void OnTriggerEnter(Collider other) => Destroy(this.gameObject);
}
