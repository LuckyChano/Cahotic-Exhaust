using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IStates
{
    Enemy enemy;
    EnemyAI movementAI;
    //Entity enemyEntity;

    public EnemyIdleState(Enemy enemy, EnemyAI movementAI)
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
            movementAI.ArtificialUpdate();

        if(movementAI.distanceToPlayer < movementAI.distanceToFollowPlayer || movementAI.isAggroed)
            enemy.fsm.ChangeState(1);
    }

    public void OnUpdate()
    {
        enemy.animator.SetBool("isMoving", enemy.navMeshAgent.velocity.magnitude > 0.1f);
        enemy.animator.SetFloat("velocity", enemy.navMeshAgent.velocity.magnitude);
    }
}
