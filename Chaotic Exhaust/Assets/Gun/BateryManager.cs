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
    public GameObject charge25;
    public GameObject charge50;
    public GameObject charge75;
    public GameObject charge100;
    public Sprite emptyBatery;
    public Sprite filledBatery;
    //public Text porcentaje;
    

    // Update is called once per frame
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
            charge25.gameObject.SetActive(false);
        }

        if(isOn == true && charge > 0)
        {
            charge -= lostCharge * Time.deltaTime;
        }

        if(charge > 0 && charge <= 25)
        {
            luzLinterna.intensity = 1;
            charge25.gameObject.SetActive(true);
            charge50.gameObject.SetActive(false);
        }

        if (charge > 25 && charge <= 50)
        {
            luzLinterna.intensity = 1.5f;
            charge25.gameObject.SetActive(false);
            charge50.gameObject.SetActive(true);
            charge75.gameObject.SetActive(false);
        }

        if (charge > 50 && charge <= 75)
        {
            luzLinterna.intensity = 2;
            charge25.gameObject.SetActive(false);
            charge50.gameObject.SetActive(false);
            charge75.gameObject.SetActive(true);
            charge100.gameObject.SetActive(false);
        }

        if (charge > 75 && charge <= 100)
        {
            luzLinterna.intensity = 2.5f;
            charge25.gameObject.SetActive(false);
            charge50.gameObject.SetActive(false);
            charge75.gameObject.SetActive(false);
            charge100.gameObject.SetActive(true);
        }
    }

   
}
