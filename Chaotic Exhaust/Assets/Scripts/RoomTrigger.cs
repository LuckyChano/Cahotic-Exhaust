using UIManager;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int enemyMin = 0;

    public Animator smartDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            CloseDoor();
            enemyCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OpenDoor();
        }
        
        if (!other.isTrigger && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
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
