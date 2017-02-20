using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class castScript : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Awake () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spellScript.spell_1)
			text.text = "You know spell. Push Enter to use it!";
		else
			text.text = "You don't know needed spell. Go back and find it!";
	}
}
