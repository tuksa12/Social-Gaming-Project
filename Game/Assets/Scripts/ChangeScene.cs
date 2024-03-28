using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button button;
    public string sceneName;

    public void OnChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
