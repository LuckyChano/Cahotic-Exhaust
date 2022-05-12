using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;

    public float distanceToPoint = 2;
    public float distanceToFollowPlayer = 10;
    public float walkSpeed = 2;
    public float runSpeed = 6;

    private Transform _enemyTransform;

    private GameObject _player;

    private int _i = 0;
    private float _distanceToPlayer;

    public EnemyAI(Enemy enemy, GameObject target)
    {
        navMeshAgent = enemy.navMeshAgent;
        destinations = enemy.destinations;
        _enemyTransform = enemy.transform;
        _player = target;
    }

    public void ArtificialStart()
    {
        if (destinations.Length == 0)
        {
            return;
        }
        navMeshAgent.destination = destinations[0].position;
    }

    public void ArtificialUpdate()
    {
        _distanceToPlayer = Vector3.Distance(_enemyTransform.position, _player.transform.position);

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
        if (destinations.Length == 0)
        {
            return;
        }
        navMeshAgent.destination = destinations[_i].position;

        if (Vector3.Distance(_enemyTransform.position, destinations[_i].position) <= distanceToPoint)
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