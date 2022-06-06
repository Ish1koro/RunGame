using UnityEngine;

/// <summary>
/// �v���C���[�̓��́A����
/// </summary>
public class PlayerController : CharacterController
{
    #region ���N���X�Q��
    private PlayerInput _playerin = default;

    private PlayerData _playerData = default;
    #endregion

    #region GameObject
    /// <summary>
    /// �|�[�Y����UI
    /// </summary>
    [SerializeField] private GameObject _pause_UI = default;
    #endregion

    #region float
    private float _move_Distance = default;
    public float _player_Score
    {
        get { return _move_Distance;}
    }
    #endregion

    //-------------------------------------------------------------

    protected override void Awake()
    {
        base.Awake();

        _playerin = new PlayerInput();

        _playerData = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        base.Update();
        
        // �|�[�Y����
        Pause();

        //�|�[�Y��Ԃ���Ȃ����
        if (!_isPause)
        {
            // �X�R�A�����Z
            GetDistanse();
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Player�̓��͂��Ƃ郁�\�b�h
    /// </summary>
    protected override void InputMethod()
    {
        // �W�����v���͎擾
        _isJump = _playerin.InGame.Jump.triggered;

        // �|�[�Y���͎擾
        _isPause = _playerin.InGame.Pause.triggered;
    }

    //-------------------------------------------------------------

    protected override void Death()
    {
        base.Death();

        _playerData.PlayScore(_player_Score);
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

    /// <summary>
    /// �|�[�YTimeScale��0�ɂ���
    /// </summary>
    private void Pause()
    {
        if (_isPause)
        {
            _pause_UI.SetActive(true);
            Time.timeScale = Variables._zero;
        }
        else
        {
            _pause_UI.SetActive(false);
            Time.timeScale = Variables._one;
        }
    }

    //InputSystem--------------------------------------------------

    private void OnEnable()
    {
        _playerin.Enable();
    }

    private void OnDisable()
    {
        _playerin.Disable();
    }
}