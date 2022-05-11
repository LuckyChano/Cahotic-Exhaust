using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void PlayerLife(Collider entity)
    {
        entity.GetComponent<PlayerHealth>();
    }
    
    private void PlayerBattery(Collider entity)
    {
        
    }

}
