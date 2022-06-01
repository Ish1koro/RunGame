using UnityEngine;

/// <summary>
/// �G�ƃv���C���[�̐e�N���X
/// </summary>
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
    private int _character_Move_Speed = Variables._three;

    private int _life = default;

    private int _state = default;
    #endregion

    #region float

    private float _fall_Timer = default;

    #endregion

    #region bool
    /// <summary>
    /// �_���[�W�����̔���
    /// </summary>
    protected bool _isDamage = default;

    /// <summary>
    /// ���S�����̔���
    /// </summary>
    protected bool _isDeath = default;

    /// <summary>
    /// �n�ʂ̒��n����
    /// </summary>
    /// <returns>Ground�̃��C���[��������true</returns>
    protected bool _isGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Variables._character_height, Variables._ground_Layer);
    }

    public bool _isJump = default;
    public bool _isPause = default;
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        InputMethod();

        // �ړ�
        Move();

        // ���n����ɂ���ĕύX
        if (_isGround())
        {
            // �W�����v���ł����
            if (_isJump)
            {
                // �W�����v�̃��\�b�h
                Jump();

                return;
            }
            _fall_Timer = Variables._zero;
        }
        else
        {
            // �����̃��\�b�h
            Fall();
        }

        // velocity�ɓ����
        _rb.velocity = (Vector3)_move_Vector;
    }

    //-------------------------------------------------------------

    private void FixedUpdate()
    {
        CharacterAnimation();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ���͂̃N���X(�e�ł͂�����Ȃ�)
    /// </summary>
    protected virtual void InputMethod()
    {

    }

    //-------------------------------------------------------------

    /// <summary>
    /// Character�̈ړ�
    /// </summary>
    protected virtual void Move()
    {
        _move_Vector.x = _character_Move_Speed;
    }

    //-------------------------------------------------------------
    
    /// <summary>
    /// Jump����
    /// </summary>
    protected virtual void Jump()
    {
        _move_Vector.y += Variables._two;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �d�͂̏���
    /// </summary>
    private void Fall()
    {
        _fall_Timer += Time.deltaTime;

        _move_Vector.y = Variables._default_Gravity / (_fall_Timer * _fall_Timer);
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
    private void CharacterAnimation()
    {
        if (_isDeath)
        {
            _state = (int)Variables.CharaStats.Death;
        }
        else
        {
            if (_isJump)
            {
                _state = (int)Variables.CharaStats.Jump;
            }
            else if (!_isGround() && !_isJump)
            {
                _state = (int)Variables.CharaStats.Fall;
            }
            else if (_isDamage)
            {
                _state = (int)Variables.CharaStats.Damage;
            }
            else
            {
                _state = (int)Variables.CharaStats.Walk;
            }
        }

        _animc.Animation(_state);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ���S�����ۂ̏���
    /// </summary>
    private void Death()
    {

    }

    //-------------------------------------------------------------
}