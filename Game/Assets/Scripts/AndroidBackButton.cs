using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("PlayMenu");
        }
    }
}
