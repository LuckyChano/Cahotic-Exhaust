using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBehaviour
{
    //Si el callback es un IEnumerable, usar un metodo de ayuda para iniciarlo,
    //y usar el nuevo metodo para pasar de param.
    public delegate void ShootCallback();
    private int _hp;
    AudioSource _hitShot;
    public int hp
    {
        get { return _hp; }
    }
    ShootCallback _damageFeedback;

    public LifeBehaviour(ShootCallback callback, AudioSource hitSound, int healthPoints = 2)
    {
        _damageFeedback = callback;
        _hp = healthPoints;
        _hitShot = hitSound;
    }

    public void takeDamage(int damageTaken)
    {
        if (!_hitShot.isPlaying)
            _hitShot.Play();
        _hp -= damageTaken;
         _damageFeedback();
            
    }
}
