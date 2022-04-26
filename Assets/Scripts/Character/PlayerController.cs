using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    #region ���N���X�Q��
    /// <summary>
    /// Player�̓��͂��Ƃ�
    /// </summary>
    private PlayerInput _playerin = default;
    #endregion

    private float _move_Distance = default;

    //-------------------------------------------------------------

    protected override void Start()
    {
        base.Start();
        _playerin = GetComponent<PlayerInput>();
    }


    //-------------------------------------------------------------

    protected override void Input()
    {
        _isJump = _playerin.actions[Variables._jump].triggered;
    }

    //-------------------------------------------------------------

    protected override void Jump()
    {
        base.Jump();
    }

    //-------------------------------------------------------------
}
