using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    #region GameObject
    [SerializeField, Header("最初の選択画面")] private GameObject FirstPanel = default;
    [SerializeField, Header("名前を入力するパネル")] private GameObject NamePanel = default;
    [SerializeField, Header("ランキング画面")] private GameObject RankingPanel = default;
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

    #region ランキング画面
    /// <summary>
    /// ランキング画面を表示
    /// </summary>
    public void ChangeRanking()
    {
        RankingPanel.SetActive(true);
        FirstPanel.SetActive(false);
    }

    //-------------------------------------------------------------

    public void BackFirstPanelFromRank()
    {
        FirstPanel.SetActive(true);
        RankingPanel.SetActive(false);
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

    #region MainGame
    public void ChangeResult()
    {
        PlayerController player = GameObject.FindWithTag(Variables._player).GetComponent<PlayerController>();
        GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>().PlayScore(player._player_Score);
        SceneManager.LoadScene(Variables._result);
    }
    #endregion

    //-------------------------------------------------------------

    #region Result
    public void ChangeTitle()
    {
        Destroy(GameObject.FindWithTag(Variables._gameController));
        SceneManager.LoadScene(Variables._title);
    }
    #endregion

    //-------------------------------------------------------------
}