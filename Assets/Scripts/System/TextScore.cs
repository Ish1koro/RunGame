using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{
    private PlayerController _player = default;

    private Text _scoreText = default;

    private void Start()
    {
        _player = GameObject.FindWithTag(Variables._player).GetComponent<PlayerController>();
        _scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        NowScore();
    }

    private void NowScore()
    {
        _scoreText.text = _player._player_Score.ToString() + Variables._unit;
    }
}
