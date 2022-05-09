using UnityEngine;

public class StageController : MonoBehaviour
{
    #region GameObject
    /// <summary>
    /// 生成するステージ
    /// </summary>
    [SerializeField] private GameObject[] _stage_Object = default;
    #endregion

    #region Vector3
    /// <summary>
    /// 生成する位置
    /// </summary>
    private Vector3 _stage_Generate_Position = default;
    #endregion

    #region int
    /// <summary>
    /// 生成するステージの番号
    /// </summary>
    private int _stage_Number = default;
    #endregion

    /// <summary>
    /// Stage生成
    /// </summary>
    private void GenerateStage()
    {
        // ステージの番号をランダムで生成
        _stage_Number = Random.Range(Variables._zero, _stage_Object.GetLength(Variables._zero));
        // 生成する位置を更新
        _stage_Generate_Position.x += Variables._six;
        // ステージを生成
        Instantiate(_stage_Object[_stage_Number], _stage_Generate_Position, Quaternion.identity);
    }
}
