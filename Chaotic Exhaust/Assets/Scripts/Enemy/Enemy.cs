using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IsShootable
{
    //Variables Privadas por Referencia
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private EnemyAI _movement;
    private LifeBehaviour _hpComponent;
    public SkinnedMeshRenderer myRend;
    private RoomTrigger roomTrigger;

    public int hp;
    private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("RoomTrigger"))
        {
            roomTrigger = other.GetComponent<RoomTrigger>();
        }
    }

    private void Awake()
    {
        myRend = GetComponentInChildren<SkinnedMeshRenderer>();
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        _hpComponent = new LifeBehaviour(DamageFeedback, GetComponent<AudioSource>(), hp);
    }

    void Start()
    {
        _movement = new EnemyAI(this, _player);
        _movement.ArtificialStart();
    }

    void Die()
    {
        if (roomTrigger != null)
        {
            roomTrigger.OnEnemyKilled();
        }
        
        Destroy(gameObject, 0.2f);
    }

    void Update()
    {
        _movement.ArtificialUpdate();
    }

    public void Damage(int damage)
    {
        _hpComponent.takeDamage(damage);
        if (_hpComponent.hp <= 0)
        {
            Die();
        }
    }
    public void DamageFeedback()
    {
        StartCoroutine(DamagedFeedback());
    }
    public IEnumerator DamagedFeedback()
    {
        myRend.material.color = Color.red;
        yield return new WaitForSeconds(.5f);
        myRend.material.color = Color.white;

    }
}