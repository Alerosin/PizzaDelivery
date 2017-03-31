using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDeliveryUICOntroller : MonoBehaviour {
	private int fadeTime;
	private CanvasRenderer rend;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<CanvasRenderer> ();
		rend.SetAlpha (0f);
	}


	public void Bringup() {
		rend.SetAlpha (1f);
		fadeTime = 100;
		StartCoroutine (Fade());
	}

	private IEnumerator Fade() {
		while (--fadeTime > 0) {
			yield return new WaitForSeconds(0.01f);
			rend.SetAlpha (((float)fadeTime) / 100f);
		}

	}
}
