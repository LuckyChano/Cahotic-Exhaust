using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    public GameObject Huevos;
    public GameObject trampa;
    public GameObject player;
    public int danio = 15;
    private static bool activa = true;
    public float Duracion;


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (true)
            {
                trampa.SetActive(true);
                //player.GetComponent<PlayerBehaviour>().Damage(danio);
                //Pb.BarValue -= danio;
                activa = false;
                Destroy(Huevos, Duracion);
            }
        }
    }
}