using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GUI GuiPanel;
	public Camera CameraA;
	public Camera CameraB;
	public Camera CameraC;
	public GameObject GUINormal;
	public GameObject GUIKeys;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.Z))
		{
			CameraA.enabled = true;
			CameraB.enabled = false;
			CameraC.enabled = false;
		}
		
		if (Input.GetKeyUp(KeyCode.X))
		{
			CameraA.enabled = false;
			CameraB.enabled = true;
			CameraC.enabled = false;
		}
		
		if (Input.GetKeyUp(KeyCode.C))
		{
			CameraA.enabled = false;
			CameraB.enabled = false;
			CameraC.enabled = true;
		}

        if (Input.GetKey(KeyCode.Tab))
        {
            GUINormal.SetActive (false);
            GUIKeys.SetActive(true);
        }
        else
        {
            GUINormal.SetActive(true);
            GUIKeys.SetActive(false);
        }


    }
}
