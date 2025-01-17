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
    public GameObject _winScreen;
    

    int index;
    private void Start()
    {
        manager = new FuseScreenManager(OnScreen, Screens, Doors, Fuses);
        manager.ActivateScreen(0);
        manager.OnFilledFuses += EndSequence;
        manager.OnFilledFuses += SetOfEnemies;
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
        GameManager.instance.ToggleEnd();
    }

    public void SetOfEnemies()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var item in enemies)
        {
            item.TurnOff();
        }
    }

    
}
