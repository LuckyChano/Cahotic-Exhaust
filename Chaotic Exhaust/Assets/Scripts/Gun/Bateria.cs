using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    public float energy;
    private BateryManager _flashLight;

    public void Start()
    {
        _flashLight = FindObjectOfType<BateryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _flashLight.Charge(energy);
            Destroy(gameObject);
        }
    }

  
}
