using Player.Interfaces;
using UnityEngine;

public class Ranged : BaseWeapon
{
    
    
    // Start is called before the first frame update
    public override void PrimaryAttack(Vector3 fireDirection)
    {
        var newShot = Instantiate(weaponsSetup._PrimaryProjectile, transform.position, Quaternion.identity);

        var lazer = newShot.GetComponent<Lazor>();
		lazer.Initialize(weaponsSetup._PrimarySpeed, weaponsSetup._PrimaryRange, weaponsSetup._PrimaryDamage);

        lazer.Fire(fireDirection.normalized);
    }

    public override void SecondaryAttack(Vector3 fireDirection)
    {
        var newShot = Instantiate(weaponsSetup._SecondaryProjectile, transform.position, Quaternion.identity);
        newShot.GetComponent<Lazor>().Fire(fireDirection.normalized);
    }
}
