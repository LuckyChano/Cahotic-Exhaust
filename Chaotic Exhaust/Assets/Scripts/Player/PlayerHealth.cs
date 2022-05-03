using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float curHealth;
    [SerializeField] private float maxHealth;

    public Slider healthBar;
    public Animator screenFx;

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
        healthBar.value = curHealth;
        screenFx.SetFloat("hit", 1);
    }
}
