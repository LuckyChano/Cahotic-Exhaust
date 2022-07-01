using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected float _currentHealth;
    protected float _maxHealth;
    protected bool _isAlive;

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }

    //Vida que tenemos
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
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

    protected void SetLife(float playerLife)
    {
        _maxHealth = playerLife;
        _currentHealth = _maxHealth;

        _isAlive = true;
    }

    //resivir daño
    public abstract void TakeDamage(float value);

    //curacion
    public abstract void Heal(float value);

    //Muere
    public abstract void Die();
}
