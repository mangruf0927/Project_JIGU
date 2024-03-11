using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("�÷��̾� ��Ʈ�ѷ�")]
    public PlayerController controller;

    [HideInInspector] 
    public IPlayerState curState;

    public Dictionary<PlayerEnums, IPlayerState> stateDictionary;

    private void Awake()
    {
        stateDictionary = new Dictionary<PlayerEnums, IPlayerState>
        {
            {PlayerEnums.IDLE, new PlayerIdleState(this) },
            {PlayerEnums.MOVE, new PlayerMoveState(this) },
            {PlayerEnums.DODGE, new PlayerDodgeState(this) },
            {PlayerEnums.DEAD, new PlayerDeadState(this) },
        };

        if(stateDictionary.TryGetValue(PlayerEnums.IDLE, out IPlayerState newState))
        {
            // TryGetValue : Key�� �ִ��� Ȯ�ΰ� ���ÿ� Value�� ��ȯ
            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeState(PlayerEnums newStateType)
    {
        if (curState == null) return;
        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnEnter();
        }
    }
}
