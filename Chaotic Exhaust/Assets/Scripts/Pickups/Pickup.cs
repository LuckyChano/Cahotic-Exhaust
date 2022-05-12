using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    public string name;
    public string pickupText;
    public GameObject player;
    public BateryManager battery;
    public PlayerHealth health;
    public PlayerBehaviour behaviour;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<GameObject>();
            battery = other.GetComponentInChildren<BateryManager>();
            health = other.GetComponentInChildren<PlayerHealth>();
            behaviour = other.GetComponentInChildren<PlayerBehaviour>();
            
            OnPickup();
            print("picked up" + name);
        }
    }
    
    public virtual void OnPickup()
    {
        Destroy(gameObject);
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
