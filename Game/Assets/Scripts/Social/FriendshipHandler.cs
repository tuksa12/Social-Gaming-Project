using UnityEngine;

public class FriendshipHandler : MonoBehaviour
{
    class Friend
    {
        public string name;
        public int level;
        public Friend(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
    }
        
    void CallAddFriend(string username)
    {
        StartCoroutine(Client.UploadRequest("name", username, Client.SEND_FRIEND_REQUEST));
    }

    void CallAcceptFriend(string username)
    {
        StartCoroutine(Client.UploadRequest("name", username, Client.ACCEPT_FRIEND_REQUEST));
    }
}
