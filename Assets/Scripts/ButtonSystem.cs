using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField, Header("名前を入力するパネル")] private GameObject NamePanel = default;
    [SerializeField, Header("最初の選択画面")] private GameObject FirstPanel = default;

    public void OnEnterName()
    {
        NamePanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
}
