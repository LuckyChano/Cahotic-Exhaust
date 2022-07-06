using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI
{ 
    private GameObject _player;
    private Enemy _enemy;

    public float distanceToPoint = 2;
    public float distanceToFollowPlayer = 10;

    private int _i = 0;
    private float _distanceToPlayer;

    private bool isAggroed = false;

    public EnemyAI(Enemy enemy, GameObject target)
    {
        _enemy = enemy;
        _player = target;
    }

    public void ArtificialStart()
    {
        _enemy.navMeshAgent.destination = _enemy.destinations[0].position;
    }

    public void ArtificialUpdate()
    {
        _distanceToPlayer = Vector3.Distance(_enemy.transform.position, _player.transform.position);

        if (_distanceToPlayer <= distanceToFollowPlayer || isAggroed)
        {
            FollowPlayer();
        }
        /*else
        {
            EnemyPath();
        }*/
    }

    public void EnemyPath()
    {
        _enemy.navMeshAgent.speed = _enemy.walkSpeed;

        _enemy.navMeshAgent.destination = _enemy.destinations[_i].position;

        if (Vector3.Distance(_enemy.transform.position, _enemy.destinations[_i].position) <= distanceToPoint)
        {
            if (_enemy.destinations[_i] != _enemy.destinations[_enemy.destinations.Length - 1])
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
        _enemy.navMeshAgent.destination = _player.transform.position;

        _enemy.navMeshAgent.speed = _enemy.runSpeed;
    }

    public void SetAgroToFollow()
    {
        isAggroed = true;
    }
}