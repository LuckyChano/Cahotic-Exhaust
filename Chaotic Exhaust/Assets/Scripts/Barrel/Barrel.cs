using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{
    private RoomTrigger _roomTrigger;
    AudioSource hitShot;
    //public int hp = 1;
    LifeBehaviour hpComponent;
    public int hp;
    
    private void Awake()
    {
        hitShot = GetComponent<AudioSource>();
        _roomTrigger = FindObjectOfType<RoomTrigger>();
    }
    
    void Start()
    {
        hpComponent = new LifeBehaviour(DamageFeedback, hitShot, hp);
    }
    
    public void Damage(int dmg)
    {
        hpComponent.takeDamage(dmg);
    }

    public void DamageFeedback()
    {
        StartCoroutine(DamagedFeedback());
    }

    public IEnumerator DamagedFeedback()
    {

        GetComponentInChildren<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(.5f);

        GetComponentInChildren<Renderer>().material.color = Color.white;
        if (hpComponent.hp <= 0)
        { 
            Destroy(gameObject);
        }

    }
    
    public int ReturnHP()
    {
        return hpComponent.hp;
    }
}
