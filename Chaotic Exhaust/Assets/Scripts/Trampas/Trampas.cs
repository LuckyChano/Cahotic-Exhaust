using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    private static bool active = true;
    
    public GameObject egg;
    public GameObject trap;
    public PlayerHealth ph;

    public int dmg = 80;
    public float duration;
    
    [SerializeField]
    private int playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(playerLayer))
        {
            if (active)
            {
                trap.SetActive(true);
                ph.SendDamage(dmg);
                active = false;
                Destroy(egg, duration);
            }
        }
    }
}