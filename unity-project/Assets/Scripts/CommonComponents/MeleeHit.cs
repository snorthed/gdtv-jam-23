using CommonComponents.Interfaces;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CommonComponents
{
	public class MeleeHit : Projectile, IDamageDealer
	{
        private void Start()
        {
            StartCoroutine(Punch());
        }
        private IEnumerator Punch()
        {
            yield return new WaitForSeconds(_timeToLive);
            EndBullet();
        }
    }
}
