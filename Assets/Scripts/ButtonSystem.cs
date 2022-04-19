using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField, Header("���O����͂���p�l��")] private GameObject NamePanel = default;
    [SerializeField, Header("�ŏ��̑I�����")] private GameObject FirstPanel = default;

    public void OnEnterName()
    {
        NamePanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
}
