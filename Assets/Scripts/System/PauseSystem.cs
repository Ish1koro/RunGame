using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField, Header("É|Å[ÉYíÜÇÃUI")] private GameObject _pauseUI = default;


    [SerializeField] private Input _input = default;
    private bool _isPause = default;

    private void Update()
    {
        Pause();
    }

    private void Pause()
    {
        _isPause = _input.InGame.Pause.triggered;

        if (_isPause)
        {
            _pauseUI.SetActive(true);
        }
        else
        {
            _pauseUI.SetActive(false);
        }
    }
}
