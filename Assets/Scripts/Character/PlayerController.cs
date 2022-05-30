using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    #region ���N���X�Q��
    private Input _playerin = default;
    #endregion

    private float _move_Distance = default;
    public float _player_Score
    {
        get { return _move_Distance;}
    }

    //-------------------------------------------------------------

    protected override void Start()
    {
        _playerin = new Input();
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
        _isJump = _playerin.InGame.Jump.triggered;
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
