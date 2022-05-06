using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BateryManager : MonoBehaviour
{
    [SerializeField] private Light luzLinterna;
    [SerializeField] private bool isOn;
    [SerializeField] private bool isEquiped;
    public float charge;
    [SerializeField] private float lostCharge = 0.5f;
    

    [Header("Visuales")]
    [SerializeField] private TextMeshProUGUI chargePercentage;
    [SerializeField] private Slider chargeSlider;

    void Update()
    {

        charge = Mathf.Clamp(charge, 0, 100);

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
            chargeSlider.value = 0;
        }

        if(isOn && charge > 0)
        {
            charge -= lostCharge * Time.deltaTime;
            chargePercentage.text = charge.ToString("g2");
        }

        if(charge > 0 && charge <= 25)
        {
            luzLinterna.intensity = 1;
            chargeSlider.value = 25f;
        }

        if (charge > 25 && charge <= 50)
        {
            luzLinterna.intensity = 1.5f;
            chargeSlider.value = 50f;
        }

        if (charge > 50 && charge <= 75)
        {
            luzLinterna.intensity = 2;
            chargeSlider.value = 75f;
        }

        if (charge > 75 && charge <= 100)
        {
            luzLinterna.intensity = 2.5f;
            chargeSlider.value = 100;
        }
    }

   
}
