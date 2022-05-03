using System;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int enemyCount;
    [SerializeField] private int enemyMin;
    public int enemyLayer;
    public int roomLayer;
    [SerializeField] private int playerLayer;

    public Animator smartDoor;

    private void Awake()
    {
        roomLayer = gameObject.layer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(enemyLayer))
        {
            CloseDoor();
            enemyCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(playerLayer))
        {
            OpenDoor();
        }
        
        if (other.gameObject.layer.Equals(enemyLayer))
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
