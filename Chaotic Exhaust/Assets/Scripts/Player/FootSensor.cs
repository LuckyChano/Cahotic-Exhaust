using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSensor : MonoBehaviour
{
    public bool isGrounded;

    private float _contactCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _contactCount++;
        }

        if (_contactCount==1)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _contactCount--;
        }

        if (_contactCount == 0)
        {
            isGrounded = false;
        }
    }
}
