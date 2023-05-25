using CommonComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour , IDamageDealer
{
    public float Damage { get; set; }
    public SphereCollider sphereCollider;
    BaseWeapon baseWeapon;
    ParticleSystem[] explosionParticles;
    private void Start()
    {
        explosionParticles = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i<explosionParticles.Length; i++)
        {
            explosionParticles[i].Play();
        }
        sphereCollider.radius = 4f;
        Destroy(this.gameObject, 1f);
    }



}
