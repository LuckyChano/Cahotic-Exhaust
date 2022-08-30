using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    [SerializeField] private int dmg;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DamageFeedback();
        }
    }

    public void DamageFeedback()
    {
        StartCoroutine(DamagedFeedback());
    }
    
    public IEnumerator DamagedFeedback()
    {
        _playerHealth.SendDamage(dmg);

        yield return new WaitForSeconds(1f);
    }
}
