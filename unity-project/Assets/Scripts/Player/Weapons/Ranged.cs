using System.Collections;
using Player.Interfaces;
using UnityEngine;

public class Ranged : BaseWeapon
{
	private Coroutine _firing;


	// Start is called before the first frame update
	public override void BeginPrimaryAttack(Vector3 fireDirection)
	{
		Debug.Log("Start Firing");
		FireDirection = fireDirection;
		_firing = StartCoroutine(FiringRepeater());
	}

	public override void CancelPrimaryAttack(Vector3 lookDir)
	{
		StopCoroutine(_firing);

    }

    private IEnumerator FiringRepeater()
	{
		while (true)
		{
			var newShot = Instantiate(weaponsSetup._PrimaryProjectile, transform.position, Quaternion.identity);

			var lazer = newShot.GetComponent<Lazor>();
			lazer.Initialize(weaponsSetup._PrimarySpeed, weaponsSetup._PrimaryRange, weaponsSetup._PrimaryDamage);
			Debug.Log($"Shot Created {FireDirection.normalized}");

            lazer.Fire(FireDirection.normalized);
			yield return new WaitForSeconds(weaponsSetup._PrimaryCooldown);
		}
	}

	public override void SecondaryAttack(Vector3 fireDirection)
    {
    }
}
