using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{

    AudioSource hitShot;
    public int hp = 1;

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            StartCoroutine(DamagedFeedback());
        }
    }

    public IEnumerator DamagedFeedback()
    {
        if(!hitShot.isPlaying)
            hitShot.Play();

        GetComponentInChildren<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(.5f);

        if (gameObject != null)
        { 
            Destroy(gameObject);
        }
    }

    void Start()
    {
        hitShot = GetComponent<AudioSource>();
    }
}
