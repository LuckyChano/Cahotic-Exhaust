using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScreenTrigger : MonoBehaviour
{
    public Material OnScreen;
    public Material OffScreen;
    public List<GameObject> Screens = new List<GameObject> ();
    public List<GameObject> Doors = new List<GameObject> ();
    public List<GameObject> Fuses = new List<GameObject> ();
    public Light EmergencyLight;
    FuseScreenManager manager;


    int index;
    private void Start()
    {
        manager = new FuseScreenManager(OnScreen, Screens, Doors, Fuses);
        manager.ActivateScreen(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            manager.ActivateScreen(other.GetComponent<Player>().GetFuses());
        }
    }

    public void EndSequence()
    {
        EmergencyLight.GetComponent<Animator>().SetBool("IsEnd", true);
    }
}
