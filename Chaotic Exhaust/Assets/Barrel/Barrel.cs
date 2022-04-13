using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{

    AudioSource hitShot;
    //public int hp = 1;
    LifeBehaviour hpComponent;
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
            Destroy(gameObject);
    }
    private void Awake()
    {
        hitShot = GetComponent<AudioSource>();
    }
    void Start()
    {
        hpComponent = new LifeBehaviour(DamageFeedback, hitShot);
    }

    public int ReturnHP()
    {
        return hpComponent.hp;
    }
}
