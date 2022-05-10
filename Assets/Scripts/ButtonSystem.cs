using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    #region GameObject
    [SerializeField, Header("�ŏ��̑I�����")] private GameObject FirstPanel = default;
    [SerializeField, Header("���O����͂���p�l��")] private GameObject NamePanel = default;
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

    public void ChangeTitle()
    {
        SceneManager.LoadScene(Variables._title);
    }

    //-------------------------------------------------------------
}