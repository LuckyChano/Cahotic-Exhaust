using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory<T>
{
    public Inventory()
    {

    }

    //Inventario Donde amlacena objetos de tipo IItem

    public List<IItem> inventory = new List<IItem>();

    public void AddItem(IItem item)
    {
        inventory.Add(item);
    }
    public GameObject hasItem(IItem item)
    {
        GameObject returnItem = null;
        foreach (var item2 in inventory)
        {
            if (item2.ReturnItem() == item.ReturnItem())
            {
                returnItem =  item2.ReturnItem();
                break;
            }
        }
        return returnItem;
    }
}

[System.Serializable]
public class PickUpManager
{
    
    Inventory<IItem> inventory;
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
            if(!inventory.hasItem(intObject))
            {
                intObject.FirstInteracted(gadget);
            }
            inventory.AddItem(intObject);
        }
    }
    public GameObject getItem(IItem item)
    {
        if (inventory.hasItem(item) == null)
            return null;
        else return item.ReturnItem();
    }

}
