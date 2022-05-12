using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem
{
    protected float _currentHealth;
    protected float _maxHealth;
    protected bool _isAlive;

    //Vida que tenemos
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
    }

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }

    //Esta vivo?
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }
    
    public LifeSystem(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;

        _isAlive = true;
    }

    //resivir da�o
    public void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth<=0)
        {
            _currentHealth = 0;

            Die();
        }
    }

    //curacion
    public void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    //Muere
    private void Die()
    {
        _isAlive = false;
    }
}
