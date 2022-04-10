using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform destination1;
    public Transform destination2;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = destination1.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination1.position);

        if (distance < 2)
        {
            navMeshAgent.destination = destination2.position;
        }
        
    }
}
