using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IShootable
{
    private RoomTrigger _roomTrigger;
    AudioSource _hitShot;
    //public int hp = 1;
    LifeBehaviour _hpComponent;
    public int hp;
    
    private void Awake()
    {
        _hitShot = GetComponent<AudioSource>();
        _roomTrigger = FindObjectOfType<RoomTrigger>();
        _hpComponent = new LifeBehaviour(DamageFeedback, _hitShot, hp);
    }

    
    public void ShootDamage(float dmg)
    {
        _hpComponent.takeDamage(dmg);

        DamageFeedback();
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
        
        if (_hpComponent.hp <= 0)
        { 
            Destroy(gameObject);
        }

    }
    
    public float ReturnHP()
    {
        
        return _hpComponent.hp;
    }
}
