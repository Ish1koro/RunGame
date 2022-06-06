using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    /// <summary>
    /// Jsonにするクラス
    /// </summary>
    [SerializeField]
    private sealed class Data
    {
        public int _id = default;
        public string _name = default;
        public float _score = default;
    }

    private void Start()
    {
        StartCoroutine(Send());
    }

    private IEnumerator Send()
    {
        Data data = new Data();
        PlayerData playerData = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();

        // 名前を入力
        data._name = playerData._get_Name;
        // スコアを入力
        data._score = playerData._get_Score;
        // Jsonに変換
        string communicate_object = JsonUtility.ToJson(data);
        // byteに変換
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(communicate_object);
        UnityWebRequest request = new UnityWebRequest(Variables._url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
    }
}
