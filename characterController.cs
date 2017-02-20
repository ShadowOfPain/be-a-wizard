using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterController : MonoBehaviour {
	private string scene_name;
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	//public static float score ;
	//Text text;
	public static float move;
	private Animator anim; 
	private GameObject menu;
	public static bool menu_on;
	private GameObject spellbook; 
	public static bool spellbook_on;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		anim = GetComponent<Animator> ();
		//text = GetComponent <Text> ();
		menu = GameObject.Find ("Menu");
		spellbook = GameObject.Find ("Spellbook");
		//menu.SetActive (false);
		menu_on = false;
		//menuScript.spellbook_on = false;
		spellbook_on = false;

	}

	// Update is called once per frame
	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");


	}

/*	void Awake (){
		text = GetComponent <Text> ();
		score = 0;
	}*/

	void Update(){
		if (!menu_on && !spellScript.enter_spell) {
			if (grounded && (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {

				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);

			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();

			if (move != 0)
				anim.SetBool ("walk", true);
			else
				anim.SetBool ("walk", false);

			if (Input.GetKey (KeyCode.R)) {
				//Application.LoadLevel(Application.loadedLevel);
				scene_name = SceneManager.GetActiveScene ().name;
				SceneManager.LoadScene (scene_name);
			}
		}
		//text.text = "Score: " + score;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (spellbook_on == false) {
				if (menu_on == false) {				
					Cursor.visible = true;
					menu_on = true;
				} else {
					Cursor.visible = false;
					menu_on = false;
				}
			} else {
				spellbook_on = false;
				menu_on = true;
			}
			//menuScript.loadMenu (true);
			//menuScript.menu_on = true;
			spellScript.enter_spell = false;

		}
		spellbook.SetActive (spellbook_on);
		menu.SetActive(menu_on);

	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}  

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "pumpkin") {
			//score++;
			scoreScript.score++;
			Destroy (col.gameObject);
		}	
		if (col.gameObject.name == "saw") {
			scene_name = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene (scene_name);
		}
		if (col.gameObject.name == "door") {
			if (!(GameObject.Find ("pumpkin")))
				SceneManager.LoadScene ("0");
		}
	}

}
