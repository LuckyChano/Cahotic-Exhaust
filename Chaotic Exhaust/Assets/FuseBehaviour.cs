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
            other.GetComponent<Player>().FuseAmount++;
            Destroy(fuse);
        }
    }
}
