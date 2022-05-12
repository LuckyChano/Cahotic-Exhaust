using System;
using UnityEngine;

public class BatteryPickup : Pickup
{
    [SerializeField] private int charge = 25;
    public override void OnPickup()
    {
        base.OnPickup();
        
        if (battery.charge <= battery.chargeMax)
        {
            battery.Charge(charge);
        }
    }
}
