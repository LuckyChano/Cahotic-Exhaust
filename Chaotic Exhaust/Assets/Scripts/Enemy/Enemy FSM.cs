using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    Machine _fsm;

    EnemyMoveState _moveState;

    private void Start()
    {
        _fsm = new Machine();

        _fsm.AddState(0,_moveState);
    }

    private void FixedUpdate()
    {
        _fsm.FixedUpdate();
    }
    private void Update()
    {
        _fsm.Update();
    }
}
