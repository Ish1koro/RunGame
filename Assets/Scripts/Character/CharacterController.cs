using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    #region ���N���X�Q��
    /// <summary>
    /// Character��Animation���Ǘ�����N���X
    /// </summary>
    private AnimationController _animc = default;

    protected Rigidbody2D _rb = default;
    #endregion

    #region Vector2
    /// <summary>
    /// character���ړ����鋗��
    /// </summary>
    protected Vector2 _move_Vector = default;
    #endregion

    #region int
    private int _character_Move_Speed = default;

    private int _life = default;

    protected int _move_Direction = Variables._one;
    #endregion

    #region float
    /// <summary>
    /// �d�͉����x�̎���
    /// </summary>
    private float _fall_Timer = default;

    /// <summary>
    /// Jump�̋���
    /// </summary>
    /// <returns></returns>
    private float _jumpPower()
    {
        return 1;
    }
    #endregion

    #region bool
    protected bool _isJump = default;

    /// <summary>
    /// �n�ʂ̒��n����
    /// </summary>
    /// <returns>Ground�̃��C���[��������true</returns>
    protected bool _isGround()
    {
        return Physics2D.BoxCast(transform.position, Vector2.down, 90, Vector2.down * Variables._character_height, Variables._ground_Layer);
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Start()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        Move();

        if (_isGround() && _isJump)
        {
            Jump();
        }
        else if (_isGround())
        {
            _move_Vector.y = Variables._zero;
            _fall_Timer = Variables._zero;
        }
        else
        {
            Fall();
        }

        transform.position += (Vector3)_move_Vector;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ���͂̃N���X(�e�ł͂�����Ȃ�)
    /// </summary>
    protected virtual void Input()
    {

    }

    //-------------------------------------------------------------

    /// <summary>
    /// Character�̈ړ�
    /// </summary>
    protected virtual void Move()
    {
        _move_Vector.x = _character_Move_Speed * Time.deltaTime;
    }

    //-------------------------------------------------------------
    
    /// <summary>
    /// Jump����
    /// </summary>
    protected virtual void Jump()
    {
        _move_Vector.y = _jumpPower();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �d��
    /// </summary>
    private void Fall()
    {
        Debug.Log(_isGround());

        //_fall_Timer += Time.deltaTime;

        //_move_Vector.y = Variables._default_Gravity / (_fall_Timer * _fall_Timer);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// damage����
    /// </summary>
    /// <param name="damage">�U�����ꂽ�l</param>
    private void CharaLifeCalculation(int damage)
    {
        _life -= damage;

        if (_life <= Variables._zero)
        {
            Death();
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Animation�̏�������Animation�̃N���X�ɓn��
    /// </summary>
    /// <param name="state">Chara�̏��</param>
    private void CharacterAnimation(int state)
    {
        _animc.ChangeAnimation(state);
    }

    //-------------------------------------------------------------


    private void Death()
    {

    }

    //-------------------------------------------------------------
}