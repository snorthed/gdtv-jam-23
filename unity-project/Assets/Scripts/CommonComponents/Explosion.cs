using CommonComponents.Interfaces;
using UnityEngine;

public class Explosion : MonoBehaviour , IDamageDealer
{
    public float Damage { get; set; }
    [SerializeField] ParticleSystem explosionVFX;
    private void Start()
    {
        explosionVFX.Play();
        Destroy(this.gameObject, explosionVFX.main.duration);
    }



}
