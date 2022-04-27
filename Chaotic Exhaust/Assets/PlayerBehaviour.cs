using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public InteractBehaviour invManager;
    public FlashlightBehaviour Flashlight;
    public GameObject flashLightGadget;
    public bool state;
    void Start()
    {
        invManager = GetComponent<InteractBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightItem();
    }

    void FlashlightItem()
    {
        if (invManager.pickUpManager.returnItem(Flashlight) != null)
        {
            if (Input.GetKeyDown(KeyCode.F) && state == false)
                state = true;
            else if (Input.GetKeyDown(KeyCode.F) && state == true)
                state = false;
            flashLightGadget.SetActive(state);
        }
    }
}
