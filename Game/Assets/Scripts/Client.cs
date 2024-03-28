using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class Client
{
    public const string BASE_URL = "http://127.0.0.1:8000/gameserver/";
    public const string SIGN_IN = "signin/";
    public const string SIGN_UP = "signup/";
    public const string SIGN_OUT = "signout/";
    public const string ACCEPT_FRIEND_REQUEST = "accept_friend_request/";
    public const string SEND_FRIEND_REQUEST = "send_friend_request/";
    public const string UPDATE_FRIEND_LEVEL = "update_friendship_level/";
    public const string CHECK_AUTHENTIC = "check_auth/";
    public static string username = "";

    private static byte[] _downloadData;


    public static IEnumerator UploadRequest(string contentType, string data, string url)
    {
        WWWForm form = new WWWForm();
        form.AddField(contentType, data);

        using (var www = UnityWebRequest.Post(Client.BASE_URL + url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Request unsuccesfull");
            }
            else
            {
                Debug.Log("Request sent");
            }
        }
    }

    public static IEnumerator DownloadRequest(string contentType, string data, string url)
    {
        var www = UnityWebRequest.Get(BASE_URL + url);
        yield return www.SendWebRequest();
        
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Download successful");
            _downloadData = www.downloadHandler.data;
        }
    }

    public static byte[] RetrieveDownloadData()
    {
        byte[] temp = _downloadData;
        _downloadData = Array.Empty<byte>();
        return temp;
    }
}
