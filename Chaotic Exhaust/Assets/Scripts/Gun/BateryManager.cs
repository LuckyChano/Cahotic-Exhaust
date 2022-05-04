using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BateryManager : MonoBehaviour
{
    public Light luzLinterna;
    public bool isOn;
    public bool isEquiped;
    public float charge;
    public float lostCharge = 0.5f;
    

    [Header("Visuales")]
    public Slider chargeUI;
    
    void Update()
    {

        charge = Mathf.Clamp(charge, 0, 100);
        int valorBatery = (int)charge;
        //porcentaje.text = valorBatery.ToString() + "%";
        
        if(Input.GetKeyDown(KeyCode.F) && isEquiped == true)
        {
            isOn = !isOn;

            if(isOn == true)
            {
                luzLinterna.enabled = true;
            }

            if(isOn == false)
            {
                luzLinterna.enabled = false;
            }
        }

        if(charge == 0)
        {
            luzLinterna.intensity = 0;
            chargeUI.value = 0;
        }

        if(isOn == true && charge > 0)
        {
            charge -= lostCharge * Time.deltaTime;
        }

        if(charge > 0 && charge <= 25)
        {
            luzLinterna.intensity = 1;
            chargeUI.value = 2.5f;
        }

        if (charge > 25 && charge <= 50)
        {
            luzLinterna.intensity = 1.5f;
            chargeUI.value = 5.0f;
        }

        if (charge > 50 && charge <= 75)
        {
            luzLinterna.intensity = 2;
            chargeUI.value = 7.5f;
        }

        if (charge > 75 && charge <= 100)
        {
            luzLinterna.intensity = 2.5f;
            chargeUI.value = 10;
        }
    }

   
}
