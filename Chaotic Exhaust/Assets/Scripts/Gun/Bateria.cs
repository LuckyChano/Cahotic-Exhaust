using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    public float energy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BateryManager.instance.chargeBehaviour.Charge(energy);
            Destroy(gameObject);
        }
    }

  
}
