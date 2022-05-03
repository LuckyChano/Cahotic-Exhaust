using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehaviour : MonoBehaviour, IItem
{
    GameObject lightItem;

    public void FirstInteracted(GameObject gadget)
    {
        gadget.SetActive(true);
    }

    public void Do(params object[] args)
    {
        if (args[0].GetType() == typeof(bool) && args[1].GetType() == typeof(GameObject))
        {
            lightItem = (GameObject)args[1];
            lightItem.SetActive((bool)args[0]);
        }
    }

    public GameObject ReturnItem()
    {
        return gameObject;
    }
}
