using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spellScript : MonoBehaviour {
	public static bool spell_1;
	public bool newSpell;
	private GameObject spell_1_text;
	private GameObject new_spell_text;
	private float delta; 
	public GameObject spellParticle;
	private GameObject cast_enable;
	//private bool bool_cast;
	public static bool in_chest;
	public static bool enter_spell;
	private GameObject spell_enter;
	//private GameObject chest_1;

	// Use this for initialization
	void Start () {
		spell_1 = false;
		newSpell = false;
		//bool_cast = false;
		in_chest = false;
		enter_spell = false;
		spell_1_text = GameObject.Find ("spell_1");
		new_spell_text = GameObject.Find ("NewSpell");//выучено новое заклинание
		cast_enable = GameObject.Find ("Cast_enable");//всплывающая подсказка о возможности каста
		spell_enter = GameObject.Find ("Input_spell");//поле ввода заклинания

		//spell_enter = GameObject.Find ("InputField");
		//chest_1 = GameObject.Find ("chest_1");
		delta = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		spell_1_text.SetActive (spell_1);
		new_spell_text.SetActive (newSpell);
		if (newSpell) {
			delta -= Time.deltaTime;
			if ((delta < 0) || (Input.GetKeyDown (KeyCode.Escape)))
				newSpell = false;
		}

		/*if (in_chest) {
			bool_cast = true;
		} else
			bool_cast = false;*/
		if (enter_spell)
			cast_enable.SetActive (false);
		else
			cast_enable.SetActive (in_chest);

		
		spell_enter.SetActive (enter_spell);

		if (spell_1) {
			if (in_chest)
				castSpell ();
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "scroll_1") {
			spell_1 = true;
			newSpell = true;
			Instantiate (spellParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
			Destroy (col.gameObject);
		}

		if ((col.gameObject.tag == "chest") && (!inputSpellScript.was_casted)) {
			//if (spell_1 == true) {
				//castSpell ();
				//scoreScript.score += 10;
				//Destroy (col.gameObject);

			//}
			in_chest = true;
			/*if (inputSpellScript.was_casted)
				Destroy (col.gameObject);*/
		} 
	}

	void OnTriggerExit2D(Collider2D col_out) {
		if (col_out.gameObject.tag == "chest")
			in_chest = false;
	}

	void castSpell(){
		//Debug.Log ("enter");
		if (Input.GetKey (KeyCode.Return)){
			enter_spell = true; 
			Cursor.visible = true;
		}
	}
}
