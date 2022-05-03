using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    private GameObject linterna;
    public float cantidadEnergia;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            linterna.GetComponent<BateryManager>().charge += cantidadEnergia;
            Destroy(gameObject);
        }
    }

  
}
