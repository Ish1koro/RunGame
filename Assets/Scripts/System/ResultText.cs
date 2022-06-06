using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    #region 他クラス参照
    private PlayerData _data = default;
    #endregion

    #region GameObject
    [SerializeField, Header("_player_Name入力欄")]private Text _nameField = default;
    [SerializeField, Header("_player_Distance入力欄")] private Text _scoreField = default;
    #endregion

    private void Start()
    {
        _data = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();
        InputText();
    }

    /// <summary>
    /// PlayerDataから値をとってくる
    /// </summary>
    private void InputText()
    {
        _nameField.text = _data._get_Name;
        _scoreField.text = _data._get_Score.ToString();
    }
}
