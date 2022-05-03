using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform spawnPointFront;
    public Transform spawnPointBack;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    private int killPoints;
    private int killAmount;
    private bool bossIsActive;
    public int KillLimit;
    public Text counter; 

    private void Start()
    {
        InvokeRepeating("CreateEnemyLeft", 3, 4);
        InvokeRepeating("CreateEnemyRight", 4, 6);
        InvokeRepeating("CreateEnemyFront", 4, 2);
        InvokeRepeating("CreateEnemyBack", 5, 2); ;
        
    }

    private void Update()
    {
        SetCounter();
    }

    private void SetCounter()
    {
        counter.text = killAmount.ToString() + "/50";
    }

    public void IncreaseAmount(int amount)
    {
        killPoints += amount;
        killAmount++;

        if(killAmount == KillLimit)
        {
            CancelInvoke("CreateEnemyLeft");
            CancelInvoke("CreateEnemyRight");
            CancelInvoke("CreateEnemyFront");
            CancelInvoke("CreateEnemyBack");

            if (bossIsActive == false)
            {
                bossIsActive = true;
                Invoke("CreateBoss", 8);
            }
        }
    }

    private void CreateEnemyLeft()
    {
        GameObject go = Instantiate(enemyPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
        go.GetComponent<EnemyAIArena>();
    }

    private void CreateEnemyRight()
    {
        GameObject go = Instantiate(enemyPrefab, spawnPointRight.position, spawnPointRight.rotation);
        go.GetComponent<EnemyAIArena>();
    }

    private void CreateEnemyFront()
    {
        GameObject go = Instantiate(enemyPrefab, spawnPointFront.position, spawnPointFront.rotation);
        go.GetComponent<EnemyAIArena>();
    }

    private void CreateEnemyBack()
    {
        GameObject go = Instantiate(enemyPrefab, spawnPointBack.position, spawnPointBack.rotation);
        go.GetComponent<EnemyAIArena>();
    }

    private void CreateBoss()
    {
        GameObject go = Instantiate(bossPrefab, spawnPointFront.position, spawnPointFront.rotation);
        go.GetComponent<EnemyAIArena>();
    }

  
}

