using System;
using UnityEngine;

public class BatteryPickup : Pickup
{
    [SerializeField] private int charge = 25;

    public override void OnPickup()
    {
        BateryManager.instance.ChargeFlashlight(charge);
        Destroy(gameObject);
    }
}