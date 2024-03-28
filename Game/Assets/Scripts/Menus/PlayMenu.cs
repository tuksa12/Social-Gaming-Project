using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
	[SerializeField]
	private Button playButton;
	[SerializeField]
	private Button resourcesButton;
	[SerializeField]
	private Button friendsButton;
	[SerializeField]
	private Button GuildButton;
	[SerializeField]
	private Button quitButton;
	public void LoadGame()
	{
		SceneManager.LoadScene("World");
	}

	public void LoadFriends()
    {
		SceneManager.LoadScene("FriendsList");
    }
	public void LoadGuild()
	{
		SceneManager.LoadScene("GuildMenu");
	}

	public void LoadRessources()
    {
		SceneManager.LoadScene("UserItems");
		
		//Main.Instance.UserProfile.SetActive(true);
		//Main.Instance.canvasMenu.SetActive(false);
	}

	public void Quit()
    {
		Application.Quit();
    }
}
