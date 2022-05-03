using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{
    public RoomTrigger roomTrigger;
    AudioSource hitShot;
    //public int hp = 1;
    LifeBehaviour hpComponent;
    public int hp;
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
            if (gameObject.layer.Equals(roomTrigger.enemyLayer))
            {
                roomTrigger.OnEnemyKilled();
            }
            Destroy(gameObject);
        }

    }
    private void Awake()
    {
        hitShot = GetComponent<AudioSource>();
    }
    void Start()
    {
        hpComponent = new LifeBehaviour(DamageFeedback, hitShot, hp);
    }

    public int ReturnHP()
    {
        return hpComponent.hp;
    }
}
