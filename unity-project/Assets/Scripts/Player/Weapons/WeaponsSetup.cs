using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponsSetup", order = 1)]
public class WeaponsSetup : ScriptableObject
{
    public int _PrimaryDamage;
    public int _SecondaryDamage;
    public float _PrimaryRange;
    public float _SecondaryRange;
    public float _PrimarySpeed;
    public float _SecondarySpeed;
    public float _PrimaryCooldown;
    public float _SecondaryCooldown;
    public GameObject _WeaponModel;
    public GameObject _PrimaryProjectile;
    public GameObject _SecondaryProjectile;
    
}
