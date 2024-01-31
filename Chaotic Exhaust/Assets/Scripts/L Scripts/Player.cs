using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : PlayerLifeSystem, IAffectGas
{
    [Header("Player Configurations")]
    //Variables Estaticas

    //Variables Publicas por Referencia
    public Rigidbody rb;
    public FootSensor footSensor;
    public GameObject deathScreen;
    public UIManager.UIManager uiManager;


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
    public float throwForce = 500;

    public GameObject granadePrefab;
    public Transform throwPos;

    //Variables Privadas
    [SerializeField]
    private int _fuseAmount = 0;


    //Propiedades
    public PlayerMove movement
    {
        get
        {
            return _playerMove;
        }
    }
    public PlayerControl controller
    {
        get
        {
            return _playerControl;
        }
    }

    //Delegados

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        _playerControl = new PlayerControl(this);

        StartLife(playerLife);
        StartUI();
        _playerControl.Throw = Throw;
        _playerControl.Pause = uiManager.Pause;

        _playerMove = new PlayerMove(this, walkSpeed, runSpeedMultiplier, jumpForce, dashForce);

    }

    void Update()
    {
        if(IsAlive)
            _playerControl.ArtificialUpdate();
    }

    void FixedUpdate()
    {
        if (IsAlive)
            _playerControl.ArtificialFixedUpdate();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------

    public void Throw()
    {
        GameObject newGranede = Instantiate(granadePrefab, throwPos.position, throwPos.rotation);

        newGranede.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }

    public void AddFuse()
    {
        _fuseAmount++;
    }

    public int GetFuses()
    {
        return _fuseAmount;
    }


    public override void Die()
    {
        _isAlive = false;

        Cursor.lockState = CursorLockMode.None;

        screenFx.SetTrigger("die");

        var timer = 0f;
        timer += Time.deltaTime * 2;

        if(timer > 0.5f)
        {
            Time.timeScale = 0;
        }

    }

    public override void Damage(float value)
    {
        TakeDamage(value);
    }

    public override void ShootDamage(float value)
    {
        TakeDamage(value);
    }

    public void EnterGas(float dmg)
    {
        Damage(dmg);
    }

    public override void TurnOff()
    {
        
    }
}
