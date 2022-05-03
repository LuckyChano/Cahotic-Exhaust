using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    public GameObject egg;
    public GameObject trap;
    public int dmg = 80;
    private static bool active = true;
    public float duration;
    public PlayerHealth ph;
    [SerializeField] private int playerLayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(playerLayer))
        {
            if (true)
            {
                trap.SetActive(true);
                ph.SendDamage(dmg);
                active = false;
                Destroy(egg, duration);
            }
        }
    }
}