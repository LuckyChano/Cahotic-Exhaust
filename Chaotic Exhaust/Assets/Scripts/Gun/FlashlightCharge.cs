using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightCharge
{
    [SerializeField] private Light luzLinterna;

    public float lostCharge = 0.5f;
    public int chargeMax = 100;
    public int chargeMin = 0;

    private TextMeshProUGUI chargePercentage;
    private Slider chargeSlider;
    private BateryManager _bat;

    public FlashlightCharge(BateryManager bat)
    {
        _bat = bat;
        luzLinterna = bat.luzLinterna;
        chargeSlider = bat.chargeSlider;
        chargePercentage = bat.chargePercentage;
    }

    public void ArtificialUpdate()
    {
        if (_bat.charge == 0)
        {
            luzLinterna.intensity = 0;
        }
        if (_bat.charge > 100)
        {
            _bat.charge = 100;
        }
        if (_bat.isOn && _bat.charge > 0)
        {
            _bat.charge -= lostCharge * Time.deltaTime;
        }

        if (_bat.charge > 0 && _bat.charge <= 25)
        {
            luzLinterna.intensity = 1f;
        }
        if (_bat.charge > 25 && _bat.charge <= 50)
        {
            luzLinterna.intensity = 2f;
        }
        if (_bat.charge > 50 && _bat.charge <= 75)
        {
            luzLinterna.intensity = 3f;
        }
        if (_bat.charge > 75 && _bat.charge <= 101)
        {
            luzLinterna.intensity = 4f;
        }
        chargeSlider.value = Mathf.Round(_bat.charge);
        chargePercentage.text = $"{Mathf.Round(chargeSlider.value)}";
    }


    public void Charge(float amount)
    {
        _bat.charge += amount;
        _bat.charge = Mathf.Clamp(_bat.charge, chargeMin, chargeMax);
    }
}