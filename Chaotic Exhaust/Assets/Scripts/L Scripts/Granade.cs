using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public GameObject explisionEffect;

    public int granadeDamage = 2;
    public float delay=3;
    public float radius = 5;
    public float explosionForce = 2000;

    private float _countdown;
    private bool _exploded = false;

    public LayerMask damagableLayers;

    public Collider[] colliders;

    private void Start()
    {
        _countdown = delay;
    }

    private void Update()
    {
        _countdown -= Time.deltaTime;

        if (_countdown <= 0 && _exploded == false) 
        {
            Explode();
            _exploded = true;
        }
        colliders = Physics.OverlapSphere(transform.position, radius, damagableLayers);

    }

    void Explode()
    {
        Instantiate(explisionEffect, transform.position, transform.rotation);

        AudioManager.instance.Play("Granade");

        foreach (var rangeObject in colliders)
        {
            Rigidbody rb = rangeObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
            if(rb.GetComponent<IShootable>() != null)
            {
                rb.GetComponent<IShootable>().ShootDamage(granadeDamage);
            }
        }

        Destroy(gameObject);
    }
}
