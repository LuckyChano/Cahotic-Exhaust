using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity,IDamageable,IShootable
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public SkinnedMeshRenderer myRend;
    
    private EnemyAI _movement;
    private RoomTrigger _roomTrigger;
    private GameObject _player;

    public float enemyLife = 3;
    public float enemyDamage = 20;

    private void Awake()
    {
        myRend = GetComponentInChildren<SkinnedMeshRenderer>();
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartLife(enemyLife);

        _movement = new EnemyAI(this, _player);
        _movement.ArtificialStart();
    }

    void Update()
    {
        _movement.ArtificialUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(enemyDamage);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("RoomTrigger"))
        {
            _roomTrigger = other.GetComponent<RoomTrigger>();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------

    public override void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }

        StartCoroutine(DamagedFeedback());
    }

    public override void Heal(float value)
    {
        throw new NotImplementedException();
    }

    public override void Die()
    {
        if (_roomTrigger != null)
        {
            _roomTrigger.OnEnemyKilled();
        }

        //FeedBack

        Destroy(gameObject, 0.2f); ;
    }

    public override void Damage(float value)
    {
        throw new NotImplementedException();
    }

    public override void ShootDamage(float value)
    {
        TakeDamage(value);
    }

    public IEnumerator DamagedFeedback()
    {
        myRend.material.color = Color.red;
        //AudioManager.Play("SHOOTSOUND");
        yield return new WaitForSeconds(.5f);
        myRend.material.color = Color.white;
    }
}