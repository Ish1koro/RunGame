using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameOver : MonoBehaviour
{
    private GameObject _player = default;

    private ButtonController _buttonController = default;

    private float _gameOverPosition = 14.5f;

    private void Start()
    {
        _player = GameObject.FindWithTag(Variables._player);
        _buttonController = GetComponent<ButtonController>();
    }

    private void Update()
    {
        if (_player.transform.position.x > _gameOverPosition)
        {
            _buttonController.ChangeResult();
        }
    }
}
