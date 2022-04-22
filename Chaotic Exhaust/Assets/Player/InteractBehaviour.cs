using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    public List<GameObject> inventory;
    PickUpManager pickUpManager;
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
                    pickUpManager.Interact(Interact, tar);
                }
            }
        }
    }

    void Interact(GameObject objectToInteract)
    {
        if (objectToInteract == null)
        {
            return;
        }
        if(!inventory.Contains(objectToInteract))
        {
            FirstInteracted();
        }
        inventory.Add(objectToInteract);
        Destroy(objectToInteract);
    }

    void FirstInteracted()
    {

    }
}
