using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeBehaviour
{
    //Action = guarda metodos <-callback
    public Action ShootCallback;
    private float _hp;
    AudioSource _hitShot;
    public float hp
    {
        get { return _hp; }
    }

    public LifeBehaviour(Action callback, AudioSource hitSound, float healthPoints = 2)
    {
        ShootCallback = callback;
        _hp = healthPoints;
        _hitShot = hitSound;
    }

    public void takeDamage(float damageTaken)
    {
        if (!_hitShot.isPlaying)
            _hitShot.Play();
        _hp -= damageTaken;
        ShootCallback();        
    }
}
