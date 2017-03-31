using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example {
	public class InteractableNPC : MonoBehaviour {
		public string characterName;
		public DialogueMenuController dmc;

		public string talkToNode = "";

		[Header("Optional")]
		public TextAsset scriptToLoad;

		private MouseLook camController1;
		private MouseLook camController2;
		private FirstPersonDrifter fpd;

		private bool inRange = false;
		private bool mouseOver = false;
		private bool talking = false;




		// Use this for initialization
		void Start () {
			if (scriptToLoad != null) {
				FindObjectOfType<Yarn.Unity.DialogueRunner> ().AddScript (scriptToLoad);
			}

			// Needed to Pause
			camController1 = GameObject.Find("Player").transform.GetComponent<MouseLook>();
			camController2 = GameObject.Find ("Main Camera").transform.GetComponent<MouseLook> ();
			fpd = GameObject.Find("Player").transform.GetComponent<FirstPersonDrifter>();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetButtonDown("Use") && inRange && mouseOver && !talking) {
				// Initiate Conversation
				Debug.Log("Hello, let's talk.");
				//BringUpDialogue ();
				FindObjectOfType<DialogueRunner> ().StartDialogue (talkToNode);
			}

			transform.LookAt (GameObject.Find("Player").transform);
		}
			

		void OnMouseOver() {
			mouseOver = true;
		}

		void OnMouseExit() {
			mouseOver = false;
		}

		void OnTriggerEnter(Collider other) {
			if (other.gameObject.name == "Player") {
				inRange = true;
			}
		}

		void OnTriggerExit(Collider other) {
			if (other.gameObject.name == "Player") {
				inRange = false;
			}
		}

		public void BringUpDialogue() {
			Screen.lockCursor = false;

			talking = true;

			camController1.enabled = false;
			camController2.enabled = false;
			fpd.enabled = false;
		}

		public void ExitDialogue() {
			Screen.lockCursor = true;

			talking = false;

			camController1.enabled = true;
			camController2.enabled = true;
			fpd.enabled = true;
		}
	}
}