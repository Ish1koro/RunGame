using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    #region ���N���X�Q��
    /// <summary>
    /// ���O���̓N���X
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
