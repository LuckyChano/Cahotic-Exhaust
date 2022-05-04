using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI: MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    
    public float distanceToPoint = 2;
    public float distanceToFollowPlayer = 10;
    public float walkSpeed;
    public float runSpeed;

    private GameObject _player;

    private int _i = 0;
    private float _distanceToPlayer;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = destinations[0].position;

        _player = FindObjectOfType<CharMovement>().gameObject;
    }

    void Update()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (_distanceToPlayer <= distanceToFollowPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        navMeshAgent.speed = walkSpeed;
        navMeshAgent.destination = destinations[_i].position;

        if (Vector3.Distance(transform.position, destinations[_i].position) <= distanceToPoint)
        {
            if (destinations[_i] != destinations[destinations.Length - 1])
            {
                _i++;
            }
            else
            {
                _i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = _player.transform.position;
        navMeshAgent.speed = runSpeed;
    }
}
