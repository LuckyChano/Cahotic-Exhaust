using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IAffectGas
{
    public float curHealth;
    public float maxHealth;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthPercentage;
    [SerializeField] private Animator _screenFx;
    public Player player;
    void Start()
    {
        curHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = curHealth;
    }

   
    public void SendDamage(float damageValue)
    {
        curHealth -= damageValue;
        healthPercentage.text = curHealth.ToString("g2");
        healthBar.value = curHealth;
        _screenFx.SetTrigger("hit");
        if (curHealth <= 0)
        {
            PlayerBehaviour.instance.canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void EnterGas(float dmg)
    {
        player.Damage(dmg);
    }


    /*public IEnumerator PauseGame()
    {

        yield return new WaitForSeconds(0.5f);
        Time.timeScale *= 0.01f;
    }*/
}
