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
    public Image batery1;
    public Image batery2;
    public Image batery3;
    public Image batery4;
    public Sprite emptyBatery;
    public Sprite filledBatery;
    public Text porcentaje;
    

    // Update is called once per frame
    void Update()
    {

        charge = Mathf.Clamp(charge, 0, 100);
        int valorBatery = (int)charge;
        porcentaje.text = valorBatery.ToString() + "%";
        
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
            batery1.sprite = emptyBatery;
        }

        if(isOn == true && charge > 0)
        {
            charge -= lostCharge * Time.deltaTime;
        }

        if(charge > 0 && charge <= 25)
        {
            luzLinterna.intensity = 1;
            batery1.sprite = filledBatery;
            batery2.sprite = emptyBatery;
        }

        if (charge > 25 && charge <= 50)
        {
            luzLinterna.intensity = 1.5f;
            batery2.sprite = filledBatery;
            batery3.sprite = emptyBatery;
        }

        if (charge > 50 && charge <= 75)
        {
            luzLinterna.intensity = 2;
            batery3.sprite = filledBatery;
            batery4.sprite = emptyBatery;
        }

        if (charge > 75 && charge <= 100)
        {
            luzLinterna.intensity = 2.5f;
            batery4.sprite = filledBatery;
            
        }
    }

   
}
