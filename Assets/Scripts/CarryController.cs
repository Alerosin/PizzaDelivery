using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryController : MonoBehaviour {
	private bool isCarrying;
	private GameObject item;

	// Use this for initialization
	void Start () {
		isCarrying = false;
	}
	
	public bool GiveObject(GameObject obj) {
		if (isCarrying)
			return false;

		item = obj;
		isCarrying = true;
		return true;
	}

	public bool TakeObject(GameObject obj) {
		if (!isCarrying)
			return false;

		item = null;
		isCarrying = false;
		return true;
	}
}
