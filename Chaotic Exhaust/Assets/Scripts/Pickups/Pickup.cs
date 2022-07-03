using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour
{
    public string pickupText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {     
            OnPickup();
        }
    }

    public abstract void OnPickup();

}
