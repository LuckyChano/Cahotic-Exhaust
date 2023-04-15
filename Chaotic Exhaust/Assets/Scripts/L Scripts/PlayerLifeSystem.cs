using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public abstract class PlayerLifeSystem : Entity
{
    [Header("Life System")]
    public Slider healthBar;
    public TextMeshProUGUI healthDisplay;
    public Animator screenFx;


    //Si tenemos enemigos que se muestre su vida en pantalla lo agregamos con eventos o referecia de esta clase

    protected void StartUI()
    {
        healthBar.maxValue = MaxHealth;
        healthBar.value = CurrentHealth;
    }

    //Esto se hace en take damage
    protected void UpdateUI()
    {
        healthBar.value = CurrentHealth;
        healthDisplay.text = CurrentHealth.ToString("g2");
    }


    public override void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }

        screenFx.SetTrigger("hit");

        AudioManager.instance.Play("PlayerHurt");

        UpdateUI();
    }

    public override void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        //Agregar FeedBack

        UpdateUI();
    }
}
