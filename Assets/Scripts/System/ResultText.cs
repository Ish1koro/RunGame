using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    #region ���N���X�Q��
    private PlayerData _data = default;
    #endregion

    #region GameObject
    [SerializeField, Header("_player_Name���͗�")]private Text _nameField = default;
    [SerializeField, Header("_player_Distance���͗�")] private Text _scoreField = default;
    #endregion

    private void Start()
    {
        _data = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();
        InputText();
    }

    /// <summary>
    /// PlayerData����l���Ƃ��Ă���
    /// </summary>
    private void InputText()
    {
        _nameField.text = _data._get_Name;
        _scoreField.text = _data._get_Score.ToString();
    }
}
