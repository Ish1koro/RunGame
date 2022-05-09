using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField, Header("名前を入力するパネル")] private GameObject NamePanel = default;
    [SerializeField, Header("最初の選択画面")] private GameObject FirstPanel = default;
    [SerializeField, Header("開始時のボタン")] private GameObject StartButton = default;
    [SerializeField, Header("戻るボタン")] private GameObject BackButton = default;

    public void OnEnterName()
    {
        NamePanel.SetActive(true);
        FirstPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(BackButton);
    }

    public void BackPanel()
    {
        NamePanel.SetActive(false);
        FirstPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(StartButton);
    }
}