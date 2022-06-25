using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScreenTrigger : MonoBehaviour
{
    public Material OnScreen;
    public Material OffScreen;
    public List<GameObject> Screens = new List<GameObject> ();
    public List<GameObject> Doors = new List<GameObject> ();
    FuseScreenManager manager;

    int index;
    private void Start()
    {
        manager = new FuseScreenManager(OnScreen, OffScreen, Screens, Doors);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            manager.ActivateScreen();
        }
    }
}
