using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpManager
{
    public PickUpManager()
    {

    }

    public delegate void PickUpCallback(GameObject gameObject);
    //PickUpCallback pickUpCallback;

    
    public void Interact(PickUpCallback callback, IPickable GetObject)
    {
        if(GetObject != null)
        {
            callback(GetObject.ReturnObject());
        }
    }

    
}
