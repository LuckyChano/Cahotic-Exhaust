using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthPercentage;
    [SerializeField] private Animator screenFx;

    void Start()
    {
        curHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = curHealth;
    }

    private void Update()
    {
        float hit = screenFx.GetFloat("hit");

        if (hit > 0)
        {
            hit -= Time.deltaTime * 3;
            screenFx.SetFloat("hit", hit);
        }

        if (curHealth <1)
        {
            screenFx.SetBool("death", true);
        }
    }

    public void SendDamage(float damageValue)
    {
        curHealth -= damageValue;
        healthPercentage.text = curHealth.ToString("g2");
        healthBar.value = curHealth;
        screenFx.SetFloat("hit", 1);
        if (curHealth <= 0)
        {
            PlayerBehaviour.instance.canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /*public IEnumerator PauseGame()
    {

        yield return new WaitForSeconds(0.5f);
        Time.timeScale *= 0.01f;
    }*/
}
