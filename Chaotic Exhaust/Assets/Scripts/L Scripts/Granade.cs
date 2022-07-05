using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay=3;
    public float radius = 5;
    public float explosionForce = 2000;

    private float _countdown;
    private bool _exploded = false;

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
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var rangeObject in colliders)
        {
            Rigidbody rb = rangeObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
