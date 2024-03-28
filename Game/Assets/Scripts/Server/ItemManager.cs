using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private GameObject requestPrefab;
    //public GameObject item;
    Action<string> _createItemsCallback;
    //public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
            StartCoroutine(Main.Instance.Web.GetUserInfo(UserInfo.UserID));
        };
        CreateItems();
    }

    // Update is called once per frame
   public void CreateItems()
    {
        string userId = UserInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetItemsIDs(userId, _createItemsCallback));
    }
    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        //parsing the Jsonarray string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for(int i=0; i<jsonArray.Count; i++)
        {//create a few local variables
            bool isDone = false; //Are we done downloading the information
            string itemId = jsonArray[i].AsObject["itemID"];//getting the itemID from each array's row
            string id = jsonArray[i].AsObject["ID"];
            JSONObject itemInfoJson = new JSONObject();
            //create a callback to get the information from the web.cs script
            Action<string> getItemInfoCallback = (itemInfo) =>
            {//this callback will be called from web.cs once the information of that specific item has been downloaded (isdone = true)
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;//the temparray only has one value
            };
            //wait until WEB.cs calls the callback we passed as parameter
            StartCoroutine(Main.Instance.Web.GetItem(itemId, getItemInfoCallback));
            //wait until the callback is called from WEB (info finished downloading)
            yield return new WaitUntil(() => isDone == true);
           
           var itemGo = Instantiate(itemPrefab);
            //GameObject item = Instantiate(Item) as GameObject;
            Item item = itemGo.AddComponent<Item>();
            item.ID = id;
            item.ItemID = itemId;
            itemGo.transform.SetParent(this.transform);//so that it because a child of the view we are in, this way it will be spaced and scaled the way the other items are
            //itemGo.SetActive(true);
            itemGo.transform.localScale = Vector3.one;
            itemGo.transform.localPosition = Vector3.zero;


            // fil lthe information that we downloaded inside our prefab
            
                itemGo.transform.Find("Name").GetComponent<Text>().text = itemInfoJson["name"];
             itemGo.transform.Find("Price").GetComponent<Text>().text = itemInfoJson["price"];
             itemGo.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];

            //set the sell button

            itemGo.transform.Find("SellButton").GetComponent<Button>().onClick.AddListener(() => {
                Debug.Log("Button clicked");
                string iID = itemId;
                string IdInInventory = id;
                string userId = UserInfo.UserID;
                string buyerID = UserInfo.buyerID;
                
                StartCoroutine(Main.Instance.Web.RequestingAnItem(userId, buyerID, iID));
                StartCoroutine(Main.Instance.Web.SellItem( IdInInventory,buyerID, itemId, userId));

               
                itemGo.SetActive(false);
                  });

            //continue to the next Item
        }
     
    }
}
