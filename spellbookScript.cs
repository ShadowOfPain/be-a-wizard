using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spellbookScript : MonoBehaviour {
	private GameObject spellbook; 
	//public static bool spellbook_on;

	// Use this for initialization
	void Start () {
		spellbook = GameObject.Find ("Spellbook");
		//spellbook_on = false;
	}
	
	// Update is called once per frame
	void Update () {
		//spellbook.SetActive (spellbook_on);
		if (Input.GetKeyDown (KeyCode.Escape)) {
			spellbook.SetActive (false);
			//characterController.menu_on = true;


		}
	}
}
