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

    private string _player_Name = default;

    private float _player_Distance = default;

    public void EnterName()
    {
        if (GameObject.FindWithTag(Variables._name_Field).TryGetComponent(out _name))
        {
            _player_Name = _name.text;
        }
    }

    public void PlayDistance()
    {

    }
}
