using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedObject : MonoBehaviour, IPickable
{
    public GameObject interactedObject;

    public GameObject ReturnObject()
    {
        return interactedObject;
    }
}
