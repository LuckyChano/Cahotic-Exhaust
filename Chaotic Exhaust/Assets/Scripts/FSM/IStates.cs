using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStates
{
    void OnEnter();
    void OnUpdate();
    void OnFixedUpdate();
    void OnExit();
}

