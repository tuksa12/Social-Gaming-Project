using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

	public GameObject TargetChar;
    public AnimationClip Idle;
	public AnimationClip Attack01Anim;
	public AnimationClip Attack02Anim;
	public AnimationClip Attack03Anim;
	public AnimationClip GetHit01Anim;
	public AnimationClip GetHit02Anim;
	public AnimationClip GetHit03Anim;
	public AnimationClip DieAnim;
	public AnimationClip BlockAnim;
	public AnimationClip IdleSpecialAnim;
	public AnimationClip AppairAnim;
	
	//private MonoBehaviour CharControl;


	// Use this for initialization
	void Start () {

	//	CharControl = TargetChar.GetComponent<ThirdPersonController>();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.T))
		//(CharControl as MonoBehaviour).enabled = false;
		TargetChar.GetComponent<Animation>().Play (Attack01Anim.name);

        if (Input.GetKey(KeyCode.Q))
            TargetChar.GetComponent<Animation>().Play(Idle.name);

        if (Input.GetKey (KeyCode.R))
			TargetChar.GetComponent<Animation>().Play (IdleSpecialAnim.name);
		
		if (Input.GetKey (KeyCode.Y))
			TargetChar.GetComponent<Animation>().Play (Attack02Anim.name);

		if (Input.GetKey (KeyCode.U))
			TargetChar.GetComponent<Animation>().Play (Attack03Anim.name);

		if (Input.GetKey (KeyCode.I))
			TargetChar.GetComponent<Animation>().Play (GetHit01Anim.name);

		if (Input.GetKey (KeyCode.O))
			TargetChar.GetComponent<Animation>().Play (GetHit02Anim.name);

		if (Input.GetKey (KeyCode.P))
			TargetChar.GetComponent<Animation>().Play (GetHit03Anim.name);

		if (Input.GetKey (KeyCode.G))
			TargetChar.GetComponent<Animation>().Play (BlockAnim.name);

		if (Input.GetKey (KeyCode.H))
			TargetChar.GetComponent<Animation>().Play (DieAnim.name);

		if (Input.GetKey (KeyCode.J))
			TargetChar.GetComponent<Animation>().Play (AppairAnim.name);
		
		
		
	}
}
