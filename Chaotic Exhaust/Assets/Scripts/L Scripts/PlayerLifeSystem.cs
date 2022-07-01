using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class PlayerLifeSystem : Entity
{
    public Slider healthBar;
    public TextMeshProUGUI healthPercentage;

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
