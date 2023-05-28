using CommonComponents.Interfaces;
using System.Collections;
using UnityEngine;

namespace CommonComponents
{


    public class HandCannon : Projectile , IDamageDealer
    {
        private void Start()
        {
            StartCoroutine(Explode());
        }
        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(_timeToLive);
            EndBullet();
        }
    }
}