using UnityEngine;

public class StageController : MonoBehaviour
{
    #region GameObject
    /// <summary>
    /// ��������X�e�[�W
    /// </summary>
    [SerializeField] private GameObject[] _stage_Object = default;
    #endregion

    #region Vector3
    /// <summary>
    /// ��������ʒu
    /// </summary>
    private Vector3 _stage_Generate_Position = default;
    #endregion

    #region int
    /// <summary>
    /// ��������X�e�[�W�̔ԍ�
    /// </summary>
    private int _stage_Number = default;
    #endregion

    /// <summary>
    /// Stage����
    /// </summary>
    private void GenerateStage()
    {
        // �X�e�[�W�̔ԍ��������_���Ő���
        _stage_Number = Random.Range(Variables._zero, _stage_Object.GetLength(Variables._zero));
        // ��������ʒu���X�V
        _stage_Generate_Position.x += Variables._six;
        // �X�e�[�W�𐶐�
        Instantiate(_stage_Object[_stage_Number], _stage_Generate_Position, Quaternion.identity);
    }
}
