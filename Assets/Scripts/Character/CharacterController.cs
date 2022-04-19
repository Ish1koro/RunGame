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
    #endregion

    #region float

    #endregion

    #region bool
    protected bool _isGround = default;
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

        transform.position += (Vector3)_move_Vector;
    }

    //-------------------------------------------------------------

    protected virtual void Move()
    {
        _move_Vector.x = _character_Move_Speed;
    }

    //-------------------------------------------------------------
    protected virtual void Jump()
    {
        
    }

    //-------------------------------------------------------------

    private void CharaLifeCalculation(int damage)
    {
        _life -= damage;

        if (_life <= Variables._zero)
        {
            Death();
        }
    }

    //-------------------------------------------------------------

    private void CharacterAnimation(int )
    {

    }

    //-------------------------------------------------------------

    private void Death()
    {

    }

    //-------------------------------------------------------------
}