using CommonComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour , IDamageDealer
{
    public float Damage => throw new System.NotImplementedException();
    BoxCollider boxCollider;
    public bool trapEnabled;
    [SerializeField] GameObject flameVFX;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        flameVFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if (trapEnabled)
        {
            boxCollider.enabled = true;
            flameVFX.SetActive(true);

        }
        else
        {
            boxCollider.enabled = false;
            flameVFX.SetActive(false);
        }
    }
}
