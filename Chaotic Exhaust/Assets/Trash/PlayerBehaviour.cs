using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public InteractBehaviour invManager;
    public FlashlightBehaviour Flashlight;
    public GameObject FlashlightLight;
    public bool state;
    public bool canMove;
    public static PlayerBehaviour instance;
    private void Awake()
    {
        instance = this;
        canMove = true;
    }
    void Start()
    {
        invManager = GetComponent<InteractBehaviour>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    FlashlightItem();
    //}

    //void FlashlightItem()
    //{
    //    if (invManager.pickUpManager.getItem(Flashlight) != null)
    //    {
    //        if (Input.GetKeyDown(KeyCode.F) && state == false)
    //            state = true;
    //        else if (Input.GetKeyDown(KeyCode.F) && state == true)
    //            state = false;
    //        Flashlight.Do(state, FlashlightLight);
    //    }
    //}
}
