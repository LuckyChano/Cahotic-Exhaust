using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    public GameObject linterna;
    public float cantidadEnergia;
    private BateryManager _flashLight;

    public void Start()
    {
        _flashLight = FindObjectOfType<BateryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            linterna.GetComponent<BateryManager>().charge += cantidadEnergia;
            Destroy(gameObject);
        }
    }

  
}
