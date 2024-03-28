using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class GetRequests : MonoBehaviour
{
    [SerializeField]
    private GameObject RequestPrefab;
    //public GameObject item;
    Action<string> _createItemsCallback;
    //public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateRequestRoutine(jsonArrayString));
           
        };
        CreateRequest();
    }

    // Update is called once per frame
    public void CreateRequest()
    {
        string userId = UserInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetbuyerIDs(userId, _createItemsCallback));
    }
    IEnumerator CreateRequestRoutine(string jsonArrayString)
    {
        //parsing the Jsonarray string as an array

        Debug.Log(jsonArrayString);
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {//create a few local variables
            bool isDone = false; //Are we done downloading the information
            string buyerId = jsonArray[i].AsObject["buyerID"];//getting the itemID from each array's row
            UserInfo.setbuyerID(buyerId);
            string itemId = jsonArray[i].AsObject["itemID"];
            JSONObject itemInfoJson = new JSONObject();
            //create a callback to get the information from the web.cs script
            Action<string> getItemInfoCallback = (RequestInfo) =>
            {//this callback will be called from web.cs once the information of that specific item has been downloaded (isdone = true)
                isDone = true;
                JSONArray tempArray = JSON.Parse(RequestInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;//the temparray only has one value
            };
            //wait until WEB.cs calls the callback we passed as parameter
            StartCoroutine(Main.Instance.Web.GetrequestList(buyerId, itemId, getItemInfoCallback)) ;
            //wait until the callback is called from WEB (info finished downloading)
            yield return new WaitUntil(() => isDone == true);

            var RequestGO = Instantiate(RequestPrefab);
            //GameObject item = Instantiate(Item) as GameObject;
         
            RequestGO.transform.SetParent(this.transform);//so that it because a child of the view we are in, this way it will be spaced and scaled the way the other items are
            //itemGo.SetActive(true);
            RequestGO.transform.localScale = Vector3.one;
            RequestGO.transform.localPosition = Vector3.zero;


            // fil lthe information that we downloaded inside our prefab

            RequestGO.transform.Find("buyerName").GetComponent<Text>().text = itemInfoJson["username"];
            RequestGO.transform.Find("itemID").GetComponent<Text>().text = itemId;
            //RequestGO.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];

            //set the sell button

            RequestGO.transform.Find("accept").GetComponent<Button>().onClick.AddListener(() => {
                RequestGO.SetActive(false);});
             //   Debug.Log("Button clicked");
              /*  string iID = itemId;
                string IdInInventory = id;
                string userId = UserInfo.UserID;
                string buyerId = UserInfo.buyerID;
                StartCoroutine(Main.Instance.Web.SellItem( IdInInventory,buyerId, itemId, userId));
                StartCoroutine(Main.Instance.Web.RequestingAnItem(userId, "2", iID));
                
            */

            //continue to the next Item
        }

    }
}
