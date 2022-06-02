using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    #region 他クラス参照

    /// <summary>
    /// 名前入力クラス
    /// </summary>
    private InputField _name = default;

    #endregion

    #region ユーザのデータ

    /// <summary>
    /// ユーザの名前
    /// </summary>
    private string _player_Name = default;
    public string _get_Name
    {
        get { return _player_Name; }
    }

    /// <summary>
    /// ユーザが進んだ距離
    /// </summary>
    private float _player_Score = default;
    public float _get_Score
    {
        get { return _player_Score; }
    }

    /// <summary>
    /// ユーザが使うキャラ
    /// </summary>
    private int _select_Character = default;

    /// <summary>
    /// タイトルで選択したキャラクター
    /// </summary>
    public int _use_Character
    {
        get { return _select_Character; }
    }

    #endregion

    //-------------------------------------------------------------

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 名前設定
    /// </summary>
    public void EnterName()
    {
        if (GameObject.FindWithTag(Variables._name_Field).TryGetComponent(out _name))
        {
            _player_Name = _name.text;
        }
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// キャラ設定
    /// </summary>
    public void SetCharacter(int charaNumber)
    {
        _select_Character = charaNumber;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Score集計
    /// </summary>
    public void PlayScore(float score)
    {
        _player_Score = score;
    }

    //-------------------------------------------------------------
}
