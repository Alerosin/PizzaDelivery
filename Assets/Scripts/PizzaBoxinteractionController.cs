using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBoxinteractionController : MonoBehaviour {
	public Color selectionTint;
	public float maxBoxSpeed;
	public Vector3 boxCarryOffset;
	public Vector3 boxThrowForce;
	public GameObject explosion;
	public GameObject pizzaUI;

	private Renderer rend;
	private Color baseColor;
	private Transform interactionText;
	private MeshRenderer textRenderer;
	private Transform playerT;
	private Component itemHandlingScript;
	private bool canInteract = false;
	private bool canPickup = false;
	private bool isCarried = false;
	private bool canGive = false;
	private GameObject giveTo;


	public bool[] toppings = new bool[5];



	void Start() {
		rend = GetComponent<Renderer> ();
		//baseColor = rend.material.color;
		interactionText = transform.GetChild (0);
		textRenderer = interactionText.GetComponent<MeshRenderer> ();
		textRenderer.enabled = false;
		playerT = GameObject.Find ("Player").transform;

		//toppings = makePizza ();
	}

	void Update() {
		if (canInteract) {
			interactionText.LookAt (playerT.transform);
			interactionText.Rotate (new Vector3 (0f, 180f, 0f));
		}

		if (isCarried) {
			Vector3 current = transform.position;
			Vector3 target = playerT.position + (playerT.rotation * boxCarryOffset);

			float speed = ((Vector3.Distance (current, target)) * (maxBoxSpeed));

			transform.position = Vector3.MoveTowards (current, target, speed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			if (!isCarried) {			// Pick up box
				if (canPickup) {
					isCarried = true;
					//GetComponent<BoxCollider> ().enabled = false;
					GetComponent<Rigidbody> ().useGravity = false;
					textRenderer.enabled = false;
					rend.material.SetColor ("_Color", baseColor);
				}	
			} else if (isCarried) {		// Throw Away
				isCarried = false;
				GetComponent<Rigidbody> ().AddForce (playerT.rotation * boxThrowForce);
				textRenderer.enabled = true;
				//GetComponent<BoxCollider> ().enabled = true;
				GetComponent<Rigidbody> ().useGravity = true;
				StartCoroutine (GiveTo ());

			}
		}
	}

	public void SetCarried() {
		isCarried = true;
	}
		

	void OnMouseOver() {
		if (canInteract && !isCarried) {
			rend.material.SetColor ("_Color", selectionTint);
			canPickup = true;
		}
	}

	void OnMouseExit() {
		rend.material.SetColor ("_Color", baseColor);
		canPickup = false;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			textRenderer.enabled = true;
			canInteract = true;
		} else if (other.gameObject.tag == "NPC") {
			canGive = true;
			giveTo = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			textRenderer.enabled = false;
			canInteract = false;
		} else if (other.gameObject.tag == "NPC") {
			canGive = false;
			giveTo = null;
		}	
	}


	public IEnumerator GiveTo() {
		yield return new WaitForSeconds(1);
		GameObject ex = Object.Instantiate(explosion, transform.position, transform.rotation);
		//ex.transform.LookAt (playerT);
		//pizzaUI.GetComponent<PizzaDeliveryUICOntroller>().Bringup();
		//Debug.Log ("After Bringup");
		yield return new WaitForSeconds (1.5f);
		Object.Destroy (ex);
		//Debug.Log ("After Destroy ex");
		Object.Destroy (this.gameObject);
	}
}