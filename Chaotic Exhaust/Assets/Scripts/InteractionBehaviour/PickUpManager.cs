using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory<T>
{
    public Inventory()
    {

    }

    public List<GameObject> inventory = new List<GameObject>();

    public void AddItem(IItem item)
    {
        inventory.Add(item.ReturnItem());
    }
    public GameObject hasItem(GameObject item)
    {
        GameObject returnItem = null;
        foreach (var item2 in inventory)
        {
            if (item2.name == item.name)
            {
                returnItem =  item2;
                break;
            }
        }
        return returnItem;

    }
}

[System.Serializable]
public class PickUpManager
{
    public Inventory<IItem> inventory;
    public PickUpManager()
    {
        inventory = new Inventory<IItem>();
    }

    public delegate IItem PickUpCallback(GameObject gameObject);
    //PickUpCallback pickUpCallback;

    
    public void Interact(PickUpCallback callback, IPickable GetObject, GameObject gadget = null)
    {
        if(GetObject != null)
        {
            var intObject = callback(GetObject.ReturnObject());
            if(!inventory.hasItem(intObject.ReturnItem()))
            {
                intObject.FirstInteracted(gadget);
            }
            inventory.AddItem(intObject);
        }
    }
    public GameObject returnItem(IItem item)
    {
        if (inventory.hasItem(item.ReturnItem()) == null)
            return null;
        else return item.ReturnItem();
    }

}
