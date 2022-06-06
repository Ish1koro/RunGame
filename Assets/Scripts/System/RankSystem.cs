using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;
using System.Threading.Tasks;

public class RankSystem : MonoBehaviour
{
    private UnityWebRequest request = UnityWebRequest.Get("http://");

    async Task Start()
    {
        yield return request.SendWebRequest();

        await Start();
        
        //3.isNetworkError��isHttpError�ŃG���[����
        if (request.isHttpError || request.isNetworkError)
        {
            //4.�G���[�m�F
            Debug.Log(request.error);
        }
    }
}
