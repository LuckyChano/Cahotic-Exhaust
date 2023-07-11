using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Machine
{
    //coleccion de estados

    private IStates currentState;// = new BlankState();

    private Dictionary<int, IStates> statesDict = new Dictionary<int, IStates>();



    public void AddState(int key, IStates state)
    {
        if(statesDict.ContainsKey(key))
        {
            return;
        }
        statesDict.Add(key, state);
    }

    public void Update()
    {
        if(currentState != null)
            currentState.OnUpdate();
    }

    public void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    public void ChangeState(int key)
    {
        if (!statesDict.ContainsKey(key)) return;
        currentState?.OnExit();
        currentState = statesDict[key];
        currentState.OnEnter();

    }
}



