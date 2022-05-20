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
    public float _player_Score
    {
        get { return _move_Distance;}
    }

    //-------------------------------------------------------------

    protected override void Start()
    {
        // ���̓N���X�擾
        _playerin = GetComponent<PlayerInput>();
        base.Start();
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        base.Update();
        // �X�R�A�����Z
        GetDistanse();
    }

    //-------------------------------------------------------------

    protected override void Input()
    {
        // �W�����v���͎擾
        _isJump = _playerin.actions[Variables._jump].triggered;
    }

    //-------------------------------------------------------------

    protected override void Jump()
    {
        base.Jump();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ���[�U�̃X�R�A�擾
    /// </summary>
    private void GetDistanse()
    {
        _move_Distance = transform.position.x + Variables._start_position;
    }

    //-------------------------------------------------------------
}
