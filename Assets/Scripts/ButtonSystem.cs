using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField, Header("���O����͂���p�l��")] private GameObject NamePanel = default;
    [SerializeField, Header("�ŏ��̑I�����")] private GameObject FirstPanel = default;
    [SerializeField, Header("�J�n���̃{�^��")] private GameObject StartButton = default;
    [SerializeField, Header("�߂�{�^��")] private GameObject BackButton = default;

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