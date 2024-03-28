
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class addFriends : MonoBehaviour
{
    [SerializeField]
    private GameObject friendsprefab;
    //public GameObject item;
    Action<string> _createfriendsCallback;
    //public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        _createfriendsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateFriendsRoutine(jsonArrayString));
        };
        showFriends();
    }

    // Update is called once per frame
    public void showFriends()
    {
        string userId = UserInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetFriendsIDs(userId, _createfriendsCallback));
    }
    IEnumerator CreateFriendsRoutine(string jsonArrayString)
    {
        //parsing the Jsonarray string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {//create a few local variables
            bool isDone = false; //Are we done downloading the information
            string receiver = jsonArray[i].AsObject["FriendID"];//getting the itemID from each array's row
            //string id = jsonArray[i].AsObject["ID"];
            JSONObject itemInfoJson = new JSONObject();
            //create a callback to get the information from the web.cs script
            Action<string> getItemInfoCallback = (friendInfo) =>
            {//this callback will be called from web.cs once the information of that specific item has been downloaded (isdone = true)
                isDone = true;
                JSONArray tempArray = JSON.Parse(friendInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;//the temparray only has one value
            };
            //wait until WEB.cs calls the callback we passed as parameter
            StartCoroutine(Main.Instance.Web.GetFriendsList(receiver, getItemInfoCallback));
            //wait until the callback is called from WEB (info finished downloading)
            yield return new WaitUntil(() => isDone == true);

            var friendGO = Instantiate(friendsprefab);
            //GameObject item = Instantiate(Item) as GameObject;
            //Item friend = friendGO.AddComponent<Item>();
           
            friendGO.transform.SetParent(this.transform);//so that it because a child of the view we are in, this way it will be spaced and scaled the way the other items are
            //itemGo.SetActive(true);
            friendGO.transform.localScale = Vector3.one;
            friendGO.transform.localPosition = Vector3.zero;


            // fil lthe information that we downloaded inside our prefab
          
            friendGO.transform.Find("Name").GetComponent<Text>().text = itemInfoJson["username"];
            friendGO.transform.Find("LevelOfFriend").GetComponent<Text>().text = itemInfoJson["level"];
            //friendGO.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];

            //set the sell button

           // friendGO.transform.Find("SellButton").GetComponent<Button>().onClick.AddListener(() => {
            //    Debug.Log("Button clicked");
             //   string iID = receiver;
              //  string IdInInventory = id;
              //  string userId = UserInfo.UserID;
               // StartCoroutine(Main.Instance.Web.SellItem(IdInInventory, receiver, userId));
            //});

            //continue to the next Item
        }

    }
}

