using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public SkinnedMeshRenderer myRend;
    
    private EnemyAI _movement;
    private RoomTrigger _roomTrigger;
    private Player _player;
    private Animator _animator;
    [SerializeField] private Collider colliderMano;

    public float enemyLife = 5;
    public float enemyDamage = 20;
    public float walkSpeed = 2;
    public float runSpeed = 6;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
        myRend = GetComponentInChildren<SkinnedMeshRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        StartLife(enemyLife);

        _movement = new EnemyAI(this, _player.gameObject);
        _movement.ArtificialStart();
    }

    void Update()
    {
        _movement.ArtificialUpdate();

        _animator.SetBool("isMoving", navMeshAgent.velocity.magnitude > 0.1f);
        _animator.SetFloat("velocity", navMeshAgent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            _animator.SetTrigger("HitTrigger");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("RoomTrigger"))
        {
            _roomTrigger = other.GetComponent<RoomTrigger>();
        }

        
    }

    private void OnTriggerStay(Collider collisionMano)
    {
        if (collisionMano.gameObject.layer == 7)
        {
            _animator.SetBool("inRange", true);
        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer == 7)
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
        //throw new NotImplementedException();
    }

    public override void Die()
    {
        if (_roomTrigger != null)
        {
            _roomTrigger.OnEnemyKilled();
        }

        AudioManager.instance.Play("EnemyDie");
        _animator.SetTrigger("Die");

        //Destroy(gameObject, 1.4f); ;
    }

    public override void Damage(float value)
    {
        _player.TakeDamage(value);
    }

    public override void ShootDamage(float value)
    {
        TakeDamage(value);
        _movement.SetAgroToFollow();
    }

    public IEnumerator DamagedFeedback()
    {
        myRend.material.color = Color.red;
        AudioManager.instance.Play("EnemyHurt");
        yield return new WaitForSeconds(.5f);
        myRend.material.color = Color.white;
    }
}