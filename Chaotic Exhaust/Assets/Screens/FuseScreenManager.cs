using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScreenManager
{
    Material p_ScreenOn;
    List<GameObject> p_Screens;
    List<GameObject> p_Doors;
    List<GameObject> p_Fuses;
    public FuseScreenManager(Material On, List<GameObject> screens, List<GameObject> doors, List<GameObject> fuses)
    {
        p_ScreenOn = On;
        p_Screens = screens;
        p_Doors = doors;
        p_Fuses = fuses;
    }

    public void ActivateScreen(int fuseNumber)
    {
        if(fuseNumber > p_Screens.Count)
        {
            return;
        }
        p_Screens[fuseNumber].GetComponent<Renderer>().material = p_ScreenOn;
        DoorAndFuse(fuseNumber);
    }

    void DoorAndFuse(int fuseNumber)
    {
        if(fuseNumber < p_Doors.Count)
        {
            p_Doors[fuseNumber].SetActive(false);
        }
        if(fuseNumber < p_Fuses.Count)
        {
            p_Fuses[fuseNumber].SetActive(true);
        }

    }
}
