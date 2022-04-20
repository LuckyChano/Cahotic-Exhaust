using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Machine
{
    //coleccion de estados

    private IStates currentState;// = new BlankState();

    private Dictionary<GunStates, IStates> statesDict = new Dictionary<GunStates, IStates>();



    public void AddState(GunStates key, IStates state)
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

    public void ChangeState(GunStates key)
    {
        if (!statesDict.ContainsKey(key)) return;
        currentState?.OnExit();
        currentState = statesDict[key];
        currentState.OnEnter();

    }
}



