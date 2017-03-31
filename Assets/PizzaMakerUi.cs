using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMakerUi : MonoBehaviour {
	public PizzaMakerController maker;
	public MouseLook camController1;
	public MouseLook camController2;
	public FirstPersonDrifter fpd;

	private bool[] toppings = new bool[5];

	void Start() {
		gameObject.SetActive (false);
	}

	public void BringUp() {
		Screen.lockCursor = false;
		GetComponent<Canvas>().enabled = true;
		gameObject.SetActive (true);

		camController1.enabled = false;
		camController2.enabled = false;
		fpd.enabled = false;
	}

	public void SetTopping(int i) {
		toppings[i] = true;
	}


	public void MakePizza() {
		maker.MakePizza (toppings);

		Screen.lockCursor = true;
		GetComponent<Canvas>().enabled = false;
		gameObject.SetActive (false);

		camController1.enabled = true;
		camController2.enabled = true;
		fpd.enabled = true;
	}
}
