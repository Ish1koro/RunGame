using System.Collections;
using UnityEngine;

//Unity 2020.3.17で動作確認済み
public class SQLTest : MonoBehaviour
{
    //サーバーアクセスのためのログイン情報
    [SerializeField] private string Url;
    [SerializeField] private string user;
    [SerializeField] private string password;
    [SerializeField] private string database;
    [SerializeField] private string sql;
    /// <summary>
    /// コルーチン結果待ちでyield returnをするために、呼び出し元もIEnumeratorにする必要がある
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        MySqlAccess mySqlAccess = GetComponent<MySqlAccess>();

        // コルーチン結果待ちをする
        string param = mySqlAccess.CreateURL(Url, user, password, database, sql);
        string res = null;
        yield return StartCoroutine(mySqlAccess.RequestMySQL(param, r => res = r));

        // 結果を処理。このサンプルではログ表示のみ
        if (mySqlAccess.IsError(res)) Debug.LogError(res);
        else Debug.Log(res);
    }
}