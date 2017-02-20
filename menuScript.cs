using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {
	private string scene_name;
	//private GameObject spellbook; 
	//public static bool spellbook_on;
	
	void Start () {
		//spellbook = GameObject.Find ("Spellbook");
		//spellbook_on = false;
	}

	void Update () {
		//spellbook.SetActive (spellbook_on);
	}

	public void ResumeButtonClicked (){
		characterController.menu_on = false;
		Cursor.visible = false;
	}

	public void newGameButtonClicked (){		
		SceneManager.LoadScene (0);
	}

	public void ExiteButtonClicked (){
		Application.Quit ();
	}

	public void SpellbookButtonClicked (){
		characterController.spellbook_on = true;
		//spellbook.SetActive (spellbook_on);
	}
}
