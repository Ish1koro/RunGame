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
    /// character���ړ������
    /// </summary>
    protected Vector2 _move_Vector = default;
    #endregion

    #region int
    /// <summary>
    /// �L�����̓����X�s�[�h
    /// </summary>
    private int _character_Move_Speed = default;

    /// <summary>
    /// �L�����̃��C�t
    /// </summary>
    private int _life = default;

    /// <summary>
    /// �L�����̏��
    /// </summary>
    private int _state = default;

    /// <summary>
    /// �O��̏����ł̃L�����̏��
    /// </summary>
    private int _old_Character_State = default;
    #endregion

    #region float
    /// <summary>
    /// �d�͂Ŏg�p�\��
    /// </summary>
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
    /// �W�����v�J�n�̔���
    /// </summary>
    public bool _isJump = default;

    /// <summary>
    /// �|�[�Y�̔���
    /// </summary>
    public bool _isPause = default;
    
    /// <summary>
    /// �n�ʂ̒��n����
    /// </summary>
    /// <returns>Ground�̃��C���[��������true</returns>
    protected bool _isGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Variables._character_height, Variables._ground_Layer);
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
        _character_Move_Speed = Variables._three;
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        // ����
        InputMethod();

        if (!_isPause)
        {
            // �ړ�
            Move();

            // ���n����ɂ���ĕύX
            if (_isGround())
            {
                Jump();
            }
            else
            {
                // �����̃��\�b�h
                Fall();
            }
        }
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
        // velocity�ɓ����
        _rb.velocity = (Vector3)_move_Vector;

        _move_Vector.x = _character_Move_Speed;
    }

    //-------------------------------------------------------------
    
    /// <summary>
    /// Jump����
    /// </summary>
    protected virtual void Jump()
    {
        // �W�����v�������ꂽ��
        if (_isJump)
        {
            //�@velocity�ɓ����
            _move_Vector.y += Variables._two;

            _rb.gravityScale = Variables._one;

            // �t���O��ύX
            _isJump = false;
        }
        else
        {
            _rb.gravityScale = Variables._zero;

            _move_Vector.y =  Variables._zero;
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �d�͂̏���
    /// </summary>
    private void Fall()
    {
        _rb.gravityScale = Variables._one;
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
            if (_isJump || _rb.velocity.y > Variables._zero)
            {
                _state = (int)Variables.CharaStats.Jump;
            }
            else if (!_isGround() || _rb.velocity.y < Variables._zero)
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

        _animc.Animation(_state, _old_Character_State);

        _old_Character_State = _state;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ���S�����ۂ̏���
    /// </summary>
    protected virtual void Death()
    {

    }

    //-------------------------------------------------------------
}