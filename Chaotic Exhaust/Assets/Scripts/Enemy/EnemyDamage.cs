using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private LayerManager _layerManager;
    private PlayerHealth _playerHealth;
    [SerializeField] private int dmg;

    private void Awake()
    {
        _layerManager = FindObjectOfType<LayerManager>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(_layerManager.playerLayer))
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
