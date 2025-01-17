using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBehaviour : MonoBehaviour
{
    public GameObject fuse;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            AudioManager.instance.Play("PickUp");
            other.GetComponent<Player>().AddFuse();
            AudioManager.instance.Play("PickUp");
            Destroy(fuse);
        }
    }
}
