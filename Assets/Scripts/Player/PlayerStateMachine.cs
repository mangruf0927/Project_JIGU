using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("�÷��̾� ��Ʈ�ѷ�")]
    public PlayerController controller;

    [HideInInspector] 
    public IPlayerState curState;

    public Dictionary<PlayerStateEnums, IPlayerState> stateDictionary;

    private void Awake()
    {
        stateDictionary = new Dictionary<PlayerStateEnums, IPlayerState>
        {
            {PlayerStateEnums.IDLE, new PlayerIdleState(this) },
            {PlayerStateEnums.MOVE, new PlayerMoveState(this) },
            {PlayerStateEnums.DODGE, new PlayerDodgeState(this) },
            {PlayerStateEnums.DEAD, new PlayerDeadState(this) },
        };

        if(stateDictionary.TryGetValue(PlayerStateEnums.IDLE, out IPlayerState newState))
        {
            // TryGetValue : Key�� �ִ��� Ȯ�ΰ� ���ÿ� Value�� ��ȯ
            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeState(PlayerStateEnums newStateType)
    {
        if (curState == null) return;
        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeInputState(PlayerStateEnums newStateType)
    {
        if (curState == null) return;
        if (!curState.inputHash.Contains(newStateType)) return;

        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            newState.OnEnter();
            curState = newState;
        }
    }

    public void ChangeLogicState(PlayerStateEnums newStateType)
    {
        if (curState == null) return;
        if (!curState.logicHash.Contains(newStateType)) return;

        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            newState.OnEnter();
            curState = newState;
        }
    }
}
