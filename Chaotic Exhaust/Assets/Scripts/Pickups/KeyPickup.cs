using System;
using TMPro;
using UnityEngine;

public class KeyPickup : Pickup
{

    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI mainText;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            winScreen.gameObject.SetActive(true);
            PlayerBehaviour.instance.canMove = false;
            mainText.text = pickupText;
            CursorUnlock();
        }
    }

    public override void OnPickup()
    {
    }
    
    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mainText.text = "";
        }
    }
}