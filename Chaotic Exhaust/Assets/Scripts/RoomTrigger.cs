using System;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int enemyMin = 0;
    private LayerManager _layerManager;

    public Animator smartDoor;

    private void Awake()
    {
        _layerManager = FindObjectOfType<LayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer.Equals(_layerManager.enemyLayer))
        {
            CloseDoor();
            enemyCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer.Equals(_layerManager.playerLayer))
        {
            OpenDoor();
        }
        
        if (!other.isTrigger && other.gameObject.layer.Equals(_layerManager.enemyLayer))
        {
            Destroy(other.gameObject);
            OnEnemyKilled();
        }
    }

    public void OnEnemyKilled()
    {
        enemyCount--;
        if (enemyCount == enemyMin)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (smartDoor != null)
        {
            smartDoor.SetBool("opened", true);
        }
    }
    
    private void CloseDoor()
    {
        if (smartDoor != null)
        {
            smartDoor.SetBool("opened", false);
        }
    }
}
