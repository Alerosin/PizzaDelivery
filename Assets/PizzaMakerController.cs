using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMakerController : MonoBehaviour {
	public PizzaMakerUi UI;
	public GameObject pizzaTemplate;
	public Transform instantiationPoint;

	private static GameObject pizzaSingleton;
	private static PizzaBoxinteractionController singletonController;

	private bool inRange = false;
	private bool canMake = false;
	private bool isMaking = false;

	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("PizzaMakerUI").GetComponent<PizzaMakerUi> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (!isMaking && inRange && canMake) {
				
				UI.BringUp ();
			}
		}
	}

	void OnMouseOver() {
		canMake = true;

	}

	void OnMouseExit() {
		canMake = false;
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player")
			inRange = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player")
			inRange = false;
	}


	public void MakePizza(bool[] toppings) {
		if (pizzaSingleton != null) {
			GameObject.Destroy (pizzaSingleton);
		}

		pizzaSingleton = GameObject.Instantiate (pizzaTemplate, instantiationPoint);
		singletonController = pizzaSingleton.GetComponent<PizzaBoxinteractionController> ();
		singletonController.SetCarried ();
	}
}
