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
    private NavMeshAgent _agent;
    private Animator _animator;

    public float enemyLife = 3;
    public float enemyDamage = 20;
    public int targetLayer;

    private void Awake()
    {
        myRend = GetComponentInChildren<SkinnedMeshRenderer>();
        _player = FindObjectOfType<Player>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        StartLife(enemyLife);

        _movement = new EnemyAI(this, _player);
        _movement.ArtificialStart();
    }

    void Update()
    {
        _movement.ArtificialUpdate();

        _animator.SetBool("isMoving", _agent.velocity.magnitude > 0.1f);
        _animator.SetFloat("velocity", _agent.velocity.magnitude);
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

        if (!other.isTrigger && other.gameObject.layer.Equals(targetLayer))
        {
            _animator.SetBool("inRange", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer.Equals(targetLayer))
        {
            _animator.SetBool("inRange", false);
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