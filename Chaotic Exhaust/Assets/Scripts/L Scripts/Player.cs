using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : PlayerLifeSystem
{
    //Variables Estaticas

    //Variables Publicas por Referencia
    public Rigidbody rb;
    public FootSensor footSensor;

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

    public int FuseAmount = -1;

    //Variables Privadas

    //Propiedades

    //Delegados

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        _playerMove = new PlayerMove(transform, rb, footSensor, walkSpeed, runSpeedMultiplier, jumpForce, dashForce);
        _playerControl = new PlayerControl(_playerMove);

        SetLife(playerLife);
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

    //-----------------------------------------------------------------------------------

    public override void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }
    }

    //curacion
    public override void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    //Muere
    public override void Die()
    {
        _isAlive = false;
    }
}
