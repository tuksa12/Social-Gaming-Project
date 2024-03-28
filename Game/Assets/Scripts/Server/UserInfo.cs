
using UnityEngine;

public static class UserInfo 
{
     public static string UserID { get; private set; }// this means that you can only set it privately, but you can publicly get the value
     static string  UserName;
     static string UserPassword;
     static string Level;
    public static string buyerID;
    static string coins;

    public static void setCredentials( string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
    }
    public static void setID(string id)
    {
        UserID = id;
    }
    public static void setCoins(string coin)
    {
        coins = coin;
    }
    public static void setLevel(string level)
    {
        Level = level;
    }
    public static void setbuyerID(string BuyerID)
    {
        buyerID = BuyerID;
    }


}
