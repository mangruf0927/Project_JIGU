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
        inputHandler.OnPlayerDodgeDirection += CheckDodgeDirection;
    }

    void ChangeIdleState()
    {
        stateMachine.ChangeInputState(PlayerStateEnums.IDLE);
    }
    void ChangeMoveState()
    {
        stateMachine.ChangeInputState(PlayerStateEnums.MOVE);
    }

    void ChangeDodgeState()
    {
        stateMachine.ChangeInputState(PlayerStateEnums.DODGE);
    }

    void CheckDirection(Vector2 dir)
    {
        controller.SetMoveDirection(dir);
    }

    void CheckDodgeDirection(Vector2 dir)
    {
        controller.SetDodgeDirection(dir);
    }
}
