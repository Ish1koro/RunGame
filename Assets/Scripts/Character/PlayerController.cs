using UnityEngine;

/// <summary>
/// �v���C���[�̓��́A����
/// </summary>
public class PlayerController : CharacterController
{
    #region ���N���X�Q��
    private PlayerInput _playerin = default;
    #endregion

    #region GameObject
    [SerializeField] private GameObject _pauseUI = default;
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
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        // �|�[�Y����
        Pause();

        if (!_isPause)
        {
            base.Update();

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

        _isPause = _playerin.InGame.Pause.triggered;

    }

    //-------------------------------------------------------------

    /// <summary>
    /// �W�����v�̃��\�b�h
    /// </summary>
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

    private void Pause()
    {
        if (_isPause)
        {
            _pauseUI.SetActive(true);
            Time.timeScale = Variables._zero;
        }
        else
        {
            _pauseUI.SetActive(false);
            Time.timeScale = Variables._one;
        }
    }

    //-------------------------------------------------------------

    private void OnEnable()
    {
        _playerin.Enable();
    }

    private void OnDisable()
    {
        _playerin.Disable();
    }
}