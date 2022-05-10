using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    #region GameObject
    [SerializeField, Header("最初の選択画面")] private GameObject FirstPanel = default;
    [SerializeField, Header("名前を入力するパネル")] private GameObject NamePanel = default;
    [SerializeField, Header("キャラの選択画面")] private GameObject CharaPanel = default;
    [SerializeField, Header("キャラの選択の決定")] private GameObject CharaSubmitButton = default;
    [SerializeField, Header("キャラの選択の戻る")] private GameObject CharaBackButton = default;
    #endregion

    //-------------------------------------------------------------

    #region 最初のパネル
    /// <summary>
    /// 始めるを押した際の処理
    /// </summary>
    public void OnEnterName()
    {
        NamePanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// 終わるを押した際の処理
    /// </summary>
    public void EndGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    #endregion

    //-------------------------------------------------------------

    #region 名前入力のパネル

    /// <summary>
    /// 決定を押した際の処理
    /// </summary>
    public void OnCharaPanel()
    {
        CharaPanel.SetActive(true);
        NamePanel.SetActive(false);
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// もどるを押した際の処理
    /// </summary>
    public void BackFirstPanel()
    {
        NamePanel.SetActive(false);
        FirstPanel.SetActive(true);
    }

    #endregion

    //-------------------------------------------------------------

    #region キャラ選択のパネル

    /// <summary>
    /// キャラ選択の際の処理
    /// </summary>
    public void OnButton()
    {
        CharaSubmitButton.SetActive(true);
        CharaBackButton.SetActive(true);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 決定を押した際の処理
    /// </summary>
    public void ChangeMainGame()
    {
        SceneManager.LoadScene(Variables._mainGame);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 戻るを押した際の処理
    /// </summary>
    public void BackNamePanel()
    {
        NamePanel.SetActive(true);
        CharaPanel.SetActive(false);
    }

    #endregion

    //-------------------------------------------------------------

    public void ChangeTitle()
    {
        SceneManager.LoadScene(Variables._title);
    }

    //-------------------------------------------------------------
}