using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour,IDamageable,IShootable
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

    protected void StartLife(float life)
    {
        _maxHealth = life;
        _currentHealth = _maxHealth;

        _isAlive = true;
    }

    //resivir daño
    public abstract void TakeDamage(float value);

    //curacion
    public abstract void Heal(float value);

    //Muere
    public abstract void Die();

    public abstract void Damage(float value);

    public abstract void ShootDamage(float value);
}
