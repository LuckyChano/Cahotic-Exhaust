using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    
    public PickUpManager pickUpManager;
    public GameObject ItemHolder;
    public GameObject gadgetFlashLight;
    void Start()
    {
        pickUpManager = new PickUpManager();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50f))
            {
                var tar = hit.transform.GetComponent<IPickable>();
                if (tar != null)
                {
                    pickUpManager.Interact(Interact, tar, gadgetFlashLight);
                }
            }
        }
    }

    IItem Interact(GameObject objectToInteract)
    {
        if (objectToInteract == null)
        {
            return null;
        }
        objectToInteract.transform.parent = ItemHolder.transform;
        objectToInteract.SetActive(false);
        return objectToInteract.GetComponent<IItem>();
    }



}
