using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void PlayerHandler();
    public event PlayerHandler OnPlayerIdle;
    public event PlayerHandler OnPlayerMove;
    public event PlayerHandler OnPlayerDodge;

    public delegate void PlayerVectorHandler(Vector2 value);
    public event PlayerVectorHandler OnPlayerCheckDirection;

    void Update()
    {
#if UNITY_EDITOR
        // �̵�
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            OnPlayerMove?.Invoke();
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 )
        {
            OnPlayerIdle?.Invoke();
        }
        
        // ���� üũ
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnPlayerCheckDirection?.Invoke(inputVector);

        // ���
        if (Input.GetButtonDown("Fire3"))
        {
            OnPlayerDodge?.Invoke();
        }
#endif
    }
}

