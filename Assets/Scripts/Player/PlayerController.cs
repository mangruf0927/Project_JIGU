using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;

    private void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log(stateMachine.curState);
        if (stateMachine.curState != null)
            stateMachine.curState.Update();
    }

    private void FixedUpdate()
    {
        if (stateMachine.curState != null)
            stateMachine.curState.FixedUpdate();
    }
}
