using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : PlayerLifeSystem
{
    //Variables Estaticas

    //Variables Publicas por Referencia
    public Rigidbody rb;
    public FootSensor footSensor;
    //agregar animator

    //public Animator screenFx;

    //Variables Privadas por Referencia
    private PlayerMove _playerMove;
    private PlayerControl _playerControl;

    //Variables Publicas
    public float playerLife = 100;

    public float walkSpeed = 7f;
    public float runSpeedMultiplier = 1.5f;
    public float jumpForce = 10f;
    public float dashForce = 12f;
        
    //Variables Privadas
    [SerializeField]
    private int _fuseAmount = 0;


    //Propiedades
    public bool IsMoving
    {
        get
        {
            return _playerMove.IsMoving;
        }
    }

    //Delegados

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        _playerMove = new PlayerMove(transform, rb, footSensor, walkSpeed, runSpeedMultiplier, jumpForce, dashForce);
        _playerControl = new PlayerControl(_playerMove);

        StartLife(playerLife);
        StartUI();
    }

    void Update()
    {
        _playerControl.ArtificialUpdate();
    }

    void FixedUpdate()
    {
        _playerControl.ArtificialFixedUpdate();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------

    public void AddFuse()
    {
        _fuseAmount++;
    }

    public int GetFuses()
    {
        return _fuseAmount;
    }

    public override void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }

        //Agregar FeedBack

        UpdateUI();
    }

    public override void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        //Agregar FeedBack

        UpdateUI();
    }

    public override void Die()
    {
        _isAlive = false;

        //Agregar FeedBack
    }

    public override void Damage(float value)
    {
        TakeDamage(value);
    }

    public override void ShootDamage(float value)
    {
        TakeDamage(value);
    }
}
