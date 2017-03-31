using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenuController : MonoBehaviour {
	public GameObject canvas;
	public MouseLook camController1;
	public MouseLook camController2;
	public FirstPersonDrifter fpd;



	// Use this for initialization
	void Start () {
		canvas.GetComponent<Canvas>().enabled = false;
		canvas.SetActive(false);
	}


	public void BringUpDialogue() {
		Screen.lockCursor = false;
		canvas.GetComponent<Canvas>().enabled = true;
		canvas.SetActive (true);

		camController1.enabled = false;
		camController2.enabled = false;
		fpd.enabled = false;
	}

	public void ExitDialogue() {
		Screen.lockCursor = true;
		canvas.GetComponent<Canvas>().enabled = false;
		canvas.SetActive(false);

		camController1.enabled = true;
		camController2.enabled = true;
		fpd.enabled = true;
	}
}
