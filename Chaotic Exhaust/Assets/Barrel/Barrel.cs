﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{

    AudioSource hitShot;
    //public int hp = 1;
    LifeBehaviour hpComponent;
    private EnemyManager _manager;
    public int hp;
    public int amount;
    public void Damage(int dmg)
    {
        hpComponent.takeDamage(dmg);
        _manager = FindObjectOfType<EnemyManager>();
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
            _manager.IncreaseAmount(amount);
            
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
