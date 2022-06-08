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

    [SerializeField] private AnimationCurve _jumpCurve = default;

    [SerializeField] private AnimationCurve _fallCurve = default;
    #endregion

    #region Vector2
    /// <summary>
    /// character���ړ������
    /// </summary>
    protected Vector2 _move_Vector = default;

    /// <summary>
    /// ���n���莞Ray���o��X���W�̈ʒu
    /// </summary>
    private Vector2 _horizontal = new Vector2(0.08f, 0);

    /// <summary>
    /// �L������X���W�̑傫��
    /// </summary>
    private Vector2 _vertical_up = new Vector2(0, 0.21f);
    private Vector2 _vertical_down = new Vector2(0, 0.24f);
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

    /// <summary>
    /// �W�����v���Ă��鎞��
    /// </summary>
    private float _jump_Timer = default;

    /// <summary>
    /// �W�����v���̏����x�v�Z
    /// </summary>
    /// <returns> -�����x(m/s) �� �d�� * ����(s) - ���x(m/s)</returns>
    private float _Initialvelocity()
    {
        return Mathf.Sqrt(-Variables._default_Gravity * Variables._two - Variables._two);
    }
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
    protected bool _isJump = default;

    /// <summary>
    /// �W�����v���̔���
    /// </summary>
    private bool _isJumping = default;

    /// <summary>
    /// �n�ʂ̒��n����
    /// </summary>
    /// <returns>Ground�̃��C���[��������true</returns>
    protected bool _isGround()
    {
        bool hit = !Physics2D.Raycast(transform.position + (Vector3)_horizontal, Vector2.down, Variables._character_height, Variables._ground_Layer) && !Physics2D.Raycast(transform.position - (Vector3)_horizontal, Vector2.down, Variables._character_height, Variables._ground_Layer);


        if (hit)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// �ړ��s�\�̔���
    /// </summary>
    /// <returns></returns>
    protected bool _canMove()
    {
        bool hit = !Physics2D.Raycast(transform.position + (Vector3)_vertical_up, Vector2.down, Variables._character_height, Variables._ground_Layer) && !Physics2D.Raycast(transform.position - (Vector3)_vertical_down, Vector2.down, Variables._character_height, Variables._ground_Layer);
        if (hit)
        {
            return true;
        }
        return false;
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _character_Move_Speed = Variables._three;
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        Debug.Log(_isGround());
        // ����
        InputMethod();

        // �ړ�
        Move();

        if ((_isGround() && _isJump) || _isJumping)
        {
            // �W�����v�̏���
            Jump();
        }
        else if (_isGround())
        {
            // ���n���̏���
            OnGround();
        }
        else if (!_isJumping)
        {
            // ��������
            Fall();
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
        transform.position += (Vector3)_move_Vector;
        if (_canMove())
        {
            _move_Vector.x = _character_Move_Speed * Time.deltaTime;
        }
        else
        {
            _move_Vector.x = Variables._zero;
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Jump����
    /// </summary>
    protected virtual void Jump()
    {
        // �W�����v�̃t���O�𗧂Ă�
        if (!_isJumping)
        {
            _isJumping = true;
        }
        
        // �W�����v���Ă��鎞�Ԃ����Z
        _jump_Timer += Time.deltaTime;

        // velocty�ɓ����
        _move_Vector.y = _jumpCurve.Evaluate(_jump_Timer) * 2 * Time.deltaTime;

        // �W�����v���Ԃ�1�b�ȏゾ������
        if (_jump_Timer >= Variables._max_Jump_Time)
        {
            // �t���O������
            _isJumping = false;
            _jump_Timer = Variables._zero;
        }
    }

    //-------------------------------------------------------------

    private void OnGround()
    {
        _move_Vector.y = Variables._zero;

        _fall_Timer = Variables._zero;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �d�͂̏���
    /// </summary>
    private void Fall()
    {
        _fall_Timer += Time.deltaTime;
        _move_Vector.y += Variables._default_Gravity * _fallCurve.Evaluate(_fall_Timer) * Time.deltaTime;
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
        if (_isJump || _isJumping)
        {
            _state = (int)Variables.CharaStats.Jump;
        }
        else if (!_isGround())
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

    protected virtual void OnBecameInvisible()
    {
        
    }

    //-------------------------------------------------------------
}