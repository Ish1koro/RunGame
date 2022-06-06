using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    #region GameObject
    [SerializeField, Header("�ŏ��̑I�����")] private GameObject FirstPanel = default;
    [SerializeField, Header("���O����͂���p�l��")] private GameObject NamePanel = default;
    [SerializeField, Header("�����L���O���")] private GameObject RankingPanel = default;
    [SerializeField, Header("�L�����̑I�����")] private GameObject CharaPanel = default;
    [SerializeField, Header("�L�����̑I���̌���")] private GameObject CharaSubmitButton = default;
    [SerializeField, Header("�L�����̑I���̖߂�")] private GameObject CharaBackButton = default;
    #endregion

    //-------------------------------------------------------------

    #region �ŏ��̃p�l��
    /// <summary>
    /// �n�߂���������ۂ̏���
    /// </summary>
    public void OnEnterName()
    {
        NamePanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// �I�����������ۂ̏���
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

    #region ���O���͂̃p�l��

    /// <summary>
    /// ������������ۂ̏���
    /// </summary>
    public void OnCharaPanel()
    {
        CharaPanel.SetActive(true);
        NamePanel.SetActive(false);
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// ���ǂ���������ۂ̏���
    /// </summary>
    public void BackFirstPanel()
    {
        NamePanel.SetActive(false);
        FirstPanel.SetActive(true);
    }

    #endregion

    //-------------------------------------------------------------

    #region �����L���O���
    /// <summary>
    /// �����L���O��ʂ�\��
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

    #region �L�����I���̃p�l��

    /// <summary>
    /// �L�����I���̍ۂ̏���
    /// </summary>
    public void OnButton()
    {
        CharaSubmitButton.SetActive(true);
        CharaBackButton.SetActive(true);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ������������ۂ̏���
    /// </summary>
    public void ChangeMainGame()
    {
        SceneManager.LoadScene(Variables._mainGame);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �߂���������ۂ̏���
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