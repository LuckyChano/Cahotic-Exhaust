using System;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI mainText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mainText.text = "[E] Pickup Key";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mainText.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mainText.text = "";
                Destroy(gameObject);
                winScreen.gameObject.SetActive(true);
                PlayerBehaviour.instance.canMove = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
