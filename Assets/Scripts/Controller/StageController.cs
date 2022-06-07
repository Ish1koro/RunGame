using UnityEngine;

public class StageController : MonoBehaviour
{
    #region GameObject
    /// <summary>
    /// �ړ�������X�e�[�W
    /// </summary>
    [SerializeField] private GameObject[] _stage_Objects = default;

    /// <summary>
    /// �ړ�������w�i
    /// </summary>
    [SerializeField] private GameObject[] _backGrounds = default;

    /// <summary>
    /// �L�����N�^�[
    /// </summary>
    private GameObject _player = default;
    #endregion

    #region Vector2
    /// <summary>
    /// ��������ʒu
    /// </summary>
    private Vector2 _stage_Position = default;
    /// <summary>
    /// �w�i�̈ʒu
    /// </summary>
    private Vector2 _background_Position = default;
    #endregion]

    #region int
    /// <summary>
    /// �ړ�������X�e�[�W�̔ԍ�
    /// </summary>
    private int _stage_Number = default;
    /// <summary>
    /// �ړ�������w�i�̔ԍ�
    /// </summary>
    private int _background_Number = default;
    #endregion


    private void Start()
    {
        _player = GameObject.FindWithTag(Variables._player);
        _stage_Number = (int)Variables.Stage.fall;
        _background_Number = (int)Variables.BackGround.flip;
        _stage_Position = _stage_Objects[_stage_Number].transform.position;
        _background_Position = _backGrounds[_background_Number].transform.position;
    }

    private void Update()
    {
        // �X�e�[�W��player���z������
        if (_player.transform.position.x >= _stage_Position.x)
        {
            // �X�e�[�W���ړ�������
            GenerateStage();
        }

        // �w�i��player���z������
        if (_player.transform.position.x >= _background_Position.x)
        {
            // �w�i���ړ�������
            MoveBackGround();
        }
    }

    /// <summary>
    /// Stage�ړ�
    /// </summary>
    private void GenerateStage()
    {
        // ���݂̂�����
        switch (_stage_Number)
        {
            case (int)Variables.Stage.basic:
                _stage_Number = (int)Variables.Stage.another;
                break;
            case (int)Variables.Stage.another:
                _stage_Number = (int)Variables.Stage.fall;
                break;
            case (int)Variables.Stage.fall:
                _stage_Number = (int)Variables.Stage.basic;
                break;
        }
        // �ړ�������ʒu���X�V
        _stage_Position.x += Variables._stage_move;
        // �X�e�[�W���ړ�
        _stage_Objects[_stage_Number].transform.position = _stage_Position;
    }

    /// <summary>
    /// �w�i�ړ�
    /// </summary>
    private void MoveBackGround()
    {
        // ���݂̔w�i�𔽓]���������̂�_background_Number�ɓ����
        switch (_background_Number)
        {
            case (int)Variables.BackGround.basic:
                _background_Number = (int)Variables.BackGround.flip;
                break;
            case (int)Variables.BackGround.flip:
                _background_Number = (int)Variables.BackGround.basic;
                break;
        }
        // �ړ�������ʒu�̍X�V
        _background_Position.x += Variables._background_move;
        // �w�i�̈ʒu���ړ�
        _backGrounds[_background_Number].transform.position = _background_Position;
    }
}
