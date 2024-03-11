using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    public PlayerController controller;
    public PlayerStateMachine stateMachine;
    public InputHandler inputHandler;

    private void Start()
    {
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerMove += ChangeMoveState;
        inputHandler.OnPlayerDodge += ChangeDodgeState;

        inputHandler.OnPlayerCheckDirection += CheckDirection;
    }

    void ChangeIdleState()
    {
        stateMachine.ChangeState(PlayerEnums.IDLE);
    }
    void ChangeMoveState()
    {
        stateMachine.ChangeState(PlayerEnums.MOVE);
    }

    void ChangeDodgeState()
    {
        stateMachine.ChangeState(PlayerEnums.DODGE);
    }

    void CheckDirection(Vector2 dir)
    {
        controller.SetMoveDirection(dir);
    }
}
