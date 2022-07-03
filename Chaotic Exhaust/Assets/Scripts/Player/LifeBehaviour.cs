using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeBehaviour
{
    //Action = guarda metodos <-callback
    public Action ShootCallback;
    private int _hp;
    AudioSource _hitShot;
    public int hp
    {
        get { return _hp; }
    }

    public LifeBehaviour(Action callback, AudioSource hitSound, int healthPoints = 2)
    {
        ShootCallback = callback;
        _hp = healthPoints;
        _hitShot = hitSound;
    }

    public void takeDamage(int damageTaken)
    {
        if (!_hitShot.isPlaying)
            _hitShot.Play();
        _hp -= damageTaken;
        ShootCallback();        
    }
}
