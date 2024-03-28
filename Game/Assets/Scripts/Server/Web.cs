using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
public class Web : MonoBehaviour
{
    public GameObject userInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator createGuild(string name)
    {
        
            WWWForm form = new WWWForm();
        form.AddField("guildName", name);

        string uri = "http://localhost/unityserver/CreateGuild.php";
            using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        
        
    }
    // Update is called once per frame

    public IEnumerator RegisterUser(string username, string password, string confirmPass)
    {
        if (password.Equals(confirmPass))
        {
            WWWForm form = new WWWForm();
            form.AddField("loginUser", username);
            form.AddField("loginPass", password);
            string uri = "http://localhost/unityserver/signup.php";
            using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }
        else Debug.Log("Passwords don't match");
    }
    public IEnumerator Login(string username, string password)//IEnumerator HAS to be called with coroutine
    {

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        //connect.text = "Loading...";
        string uri = "http://localhost/unityserver/login.php";//the URI of the login
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form)) //post request needs a uri and a form of data
        {
            yield return request.SendWebRequest();//yield is necessary with coroutines, so as to wait for the response
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                //or success
                UserInfo.setCredentials(username, password);
                UserInfo.setID(request.downloadHandler.text);//set the current ID to the user who just logged in's ID
                //UserInfo.setCoins(request.downloadHandler.text);
                //this if means we didn't login correctly, we put a small message to try again
                if ((request.downloadHandler.text.Contains("Wrong Password") ||
                    request.downloadHandler.text.Contains("Username does not exist")))
                {
                    Debug.Log("Try Agin");
                }
                else 
                {

                    //Main.Instance.login.gameObject.SetActive(false);
                  
                    //Main.Instance.canvasMenu.SetActive(true);
                    SceneManager.LoadScene("PlayMenu");

                    //show us the new view after we log in
                    //turn off the login view

                }



            }
        }
    }
    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);//the id of the person who holds some item for example youssef is ID 1 and he has the item "machete" which has an id of 2 so userID is 1 (Youssef)
        string uri = "http://localhost/unityserver/GetItemsIDs.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
        
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetFriendsIDs(string userID, System.Action<string> callback)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        string uri = "http://localhost/unityserver/GetfriendsID.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetFriendsList(string friendID, System.Action<string> callback)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("FriendID", friendID);
        string uri = "http://localhost/unityserver/Getfriends.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);
        string uri = "http://localhost/unityserver/GetItem.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
    public IEnumerator SellItem(string ID, string buyerID, string itemID, string userID)
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("ID", ID);
        form.AddField("buyerID", buyerID);
        form.AddField("itemID", itemID);
        form.AddField("userID", userID);
        string uri = "http://localhost/unityserver/SellItem.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                
            }
        }
    }
 
    public IEnumerator GetUserInfo(string userID)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        string uri = "http://localhost/unityserver/GetUserInfo.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                //or success


               JSONArray jsonArray =  JSON.Parse(request.downloadHandler.text) as JSONArray;
                
                    
                userInfo.transform.Find("GameName").GetComponent<Text>().text = jsonArray[0].AsObject["username"];
                userInfo.transform.Find("Level").GetComponent<TMPro.TextMeshProUGUI>().text = jsonArray[0].AsObject["level"];
                userInfo.transform.Find("Coins").GetComponent<TMPro.TextMeshProUGUI>().text = jsonArray[0].AsObject["coins"];


            }
        }
    }
    public IEnumerator RequestingAnItem(string sellerID, string buyerID, string itemID)
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("sellerID", sellerID);
        form.AddField("buyerID", buyerID);
        form.AddField("itemID", itemID);
        string uri = "http://localhost/unityserver/CreateRequest.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success

            }
        }
    }
    public IEnumerator GetbuyerIDs(string sellerID, System.Action<string> callback)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("sellerID", sellerID);
        string uri = "http://localhost/unityserver/GetRequestID.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetrequestList(string buyerID,string itemID ,System.Action<string> callback)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("buyerID", buyerID);
        form.AddField("itemID", itemID);
        string uri = "http://localhost/unityserver/GetRequests.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                string jsonArray = request.downloadHandler.text;
                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetCoinsBattle(string userID, string coins)//userID is the person who won the battle
    {
        
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("coins",coins);
        string uri = "http://localhost/unityserver/GetCoinsBattle.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
               
            }
        }
    }
    public IEnumerator GetRessources(string userID,string itemID)//sender is UserID of the person who sends the friend request
    {
        //sign the server needs some time to send a response, thats why we are using a callback
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("itemID", itemID);
        string uri = "http://localhost/unityserver/GetRessources.php";
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);//an error message is shown
            }
            else
            {
                Debug.Log(request.downloadHandler.text);//or success
                
            }
        }
    }


}
