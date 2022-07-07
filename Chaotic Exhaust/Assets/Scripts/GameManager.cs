using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image BlackIMG; 
    bool end = false;
    float currTime; 
    Color colorLerp;
    public static GameManager instance;
    public GameObject WinScreen;
    public void EndSequence() 
    { 
        currTime += Time.deltaTime;
        colorLerp = Color.Lerp(Color.clear, Color.black, currTime / 2);
        BlackIMG.color = colorLerp;
        if (BlackIMG.color.a == 1) 
        {
            WinScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update() 
    { 
        if (end)
            EndSequence();
    }

    public void ToggleEnd()
    {
        end = true;
    }
}
