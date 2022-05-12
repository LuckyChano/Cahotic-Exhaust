using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerUI
{
    private LifeSystem _playerLife;
    private Slider _healthBar;
    private TextMeshProUGUI _healthPercentage;

    public PlayerUI(LifeSystem playerLife, Slider healtBar, TextMeshProUGUI healthPercentage)
    {
        _playerLife = playerLife;
        _healthBar = healtBar;
        _healthPercentage = healthPercentage;

        _healthBar.maxValue = _playerLife.MaxHealth;
        _healthBar.value = _playerLife.CurrentHealth;
    }

    public void ArtificialUpdate()
    {
        _healthBar.value = _playerLife.CurrentHealth;
        _healthPercentage.text = _playerLife.CurrentHealth.ToString("g2");
    }
}
