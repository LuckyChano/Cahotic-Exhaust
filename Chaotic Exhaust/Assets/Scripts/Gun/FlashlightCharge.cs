using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightCharge
{
    [SerializeField] private Light luzLinterna;
    public float charge = 100;
    public float lostCharge = 0.5f;

    private TextMeshProUGUI chargePercentage;
    private Slider chargeSlider;
    private BateryManager _bat;

    public FlashlightCharge(BateryManager bat)
    {
        luzLinterna = bat.luzLinterna;
        chargeSlider = bat.chargeSlider;
        chargePercentage = bat.chargePercentage;
        _bat = bat;
    }

    public void ArtificialUpdate()
    {

        if (charge == 0)
        {
            luzLinterna.intensity = 0;
            chargeSlider.value = 0;
        }

        if (_bat.isOn && charge > 0)
        {
            charge -= lostCharge * Time.deltaTime;
            chargePercentage.text = charge.ToString("g2");
        }

        if (charge > 0 && charge <= 25)
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

        if (charge > 75 && charge <= 101)
        {
            luzLinterna.intensity = 2.5f;
            chargeSlider.value = 100;
        }
    }
}