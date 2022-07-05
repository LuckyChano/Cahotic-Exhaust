using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ReloadState : IStates
{
    Machine machine;
    GunBehaviour _agent;
    Animation _reloadAnim;

    public ReloadState(GunBehaviour agent,Machine fsm, Animation reloadAnim)
    {
        machine = fsm;
        _agent = agent;
        _reloadAnim = reloadAnim;
    }
    public void OnEnter()
    {
       
    }

    public void OnExit()
    {
        _agent.bulletAmout = 20;
    }

    public void OnUpdate()
    {
        machine.ChangeState(GunStates.SHOOT);
    }

}
public class ShootingState : IStates
{
    public delegate void ShootingDelegate();
    ShootingDelegate shoot;
    private GunBehaviour _agent;
    Machine machine;
    float shootTimer = 0;
    float shootSpeed;

    AudioSource _shootSound;
    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {

        if (Input.GetButton("Fire1"))
        {
            if (Time.time - shootTimer > 1 / shootSpeed && _agent.bulletAmout > 0)
            {
                shootTimer = Time.time;
                shoot();
                _shootSound.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            machine.ChangeState(GunStates.RELOAD);
        }
        if (_agent.bulletAmout <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            machine.ChangeState(GunStates.RELOAD);
        }
    }
    public ShootingState(GunBehaviour agent, Machine fsm, ShootingDelegate shoot, float _shootSpeed, AudioSource _shootSound)
    {
        _agent = agent;
        machine = fsm;
        shootSpeed = _shootSpeed;
        this.shoot = shoot;
        this._shootSound = _shootSound;
    }
}
