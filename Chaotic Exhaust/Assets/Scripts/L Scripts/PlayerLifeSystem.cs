using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class PlayerLifeSystem : Entity
{
    public Slider healthBar;
    public TextMeshProUGUI healthPercentage;
    
    //Si tenemos enemigos que se muestre su vida en pantalla lo agregamos con eventos o referecia de esta clase

    public void StartUI()
    {
        healthBar.maxValue = MaxHealth;
        healthBar.value = CurrentHealth;
    }

    //Esto se hace en take damage
    public void UpdateUI()
    {
        healthBar.value = CurrentHealth;
        healthPercentage.text = CurrentHealth.ToString("g2");
    }
}
