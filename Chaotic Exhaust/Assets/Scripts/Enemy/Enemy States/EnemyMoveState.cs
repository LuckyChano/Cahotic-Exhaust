using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : IStates
{
    Enemy enemy;
    EnemyAI movementAI;
    //Entity enemyEntity;

    public EnemyMoveState(Enemy enemy, EnemyAI movementAI)
    {
        this.enemy = enemy;
        this.movementAI = movementAI;
    }
    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void OnFixedUpdate()
    {
        if (enemy.IsAlive)
            movementAI.FollowPlayer();


        if (movementAI.distanceToPlayer > movementAI.distanceToFollowPlayer)
        {
            enemy.fsm.ChangeState(0);
        }
    }

    public void OnUpdate()
    {
        enemy.animator.SetBool("isMoving", enemy.navMeshAgent.velocity.magnitude > 0.1f);
        enemy.animator.SetFloat("velocity", enemy.navMeshAgent.velocity.magnitude);
    }
}
