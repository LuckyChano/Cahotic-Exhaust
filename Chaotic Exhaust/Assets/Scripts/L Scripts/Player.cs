using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour, IAffectGas
{
    //Variables Estaticas

    //Variables Publicas por Referencia
    public Rigidbody rb;
    public FootSensor footSensor;
    public Slider healthBar;
    public TextMeshProUGUI healthPercentage;
    //public Animator screenFx;

    public delegate void EnterOnGas(int a);

    //Variables Privadas por Referencia
    private PlayerMove _playerMove;
    private PlayerControl _playerControl;
    private LifeSystem _playerLife;
    private PlayerUI _playerUI;

    //Variables Publicas
    public float playerLife = 100;
    public float walkSpeed = 7f;
    public float runSpeedMultiplier = 1.5f;
    public float jumpForce = 10f;
    public float dashForce = 12f;

    //Variables Privadas

    //Propiedades

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

        _playerMove = new PlayerMove(transform, rb, footSensor, walkSpeed, runSpeedMultiplier, jumpForce, dashForce);
        _playerControl = new PlayerControl(_playerMove);

        _playerLife = new LifeSystem(playerLife);
        _playerUI = new PlayerUI(_playerLife, healthBar, healthPercentage);
    }

    void Update()
    {
        _playerControl.ArtificialUpdate();

        _playerUI.ArtificialUpdate();

    }

    private void FixedUpdate()
    {
        _playerControl.ArtificialFixedUpdate();
    }

    public void EnterGas(float dmg)
    {
        _playerLife.TakeDamage(dmg);
    }
}
