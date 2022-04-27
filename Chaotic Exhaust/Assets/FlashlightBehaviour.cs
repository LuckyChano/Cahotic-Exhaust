using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehaviour : MonoBehaviour, IItem
{
    public GameObject lightItem;
    public static FlashlightBehaviour instance;

    void Start()
    {
        instance = this;
    }
    public void FirstInteracted(GameObject gadget)
    {
        gadget.SetActive(true);
    }

    public GameObject ReturnItem()
    {
        return gameObject;
    }
}
