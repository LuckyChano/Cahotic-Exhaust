using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    private GameObject _player;

    public GameObject _destinations;

    private int _i = 0;
    
    public float distanceToPoint = 2;

    private float _distanceToPlayer;

    public float distanceToFollowPlayer = 10;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = destinations[0].position;

        _player = FindObjectOfType<CharMovement>().gameObject;

        _destinations = FindObjectOfType<GameObject>().gameObject;
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
    }
}
