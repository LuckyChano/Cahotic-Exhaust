using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScreenManager
{
    Material p_ScreenOn;
    Material p_ScreenOff;
    List<GameObject> p_Screens;
    List<GameObject> p_Doors;

    int index = 0;
    public FuseScreenManager(Material On, Material Off, List<GameObject> screens, List<GameObject> doors)
    {
        p_ScreenOn = On;
        p_ScreenOff = Off;
        p_Screens = screens;
        p_Doors = doors;
    }

    public void ActivateScreen()
    {
        if(index > p_Screens.Count)
        {
            return;
        }
        p_Screens[index].GetComponent<Renderer>().material = p_ScreenOn;
        UnlockDoor();
        index++;
    }

    void UnlockDoor()
    {
        if(index < p_Doors.Count)
        {
            p_Doors[index].SetActive(false);
        }
    }
}
