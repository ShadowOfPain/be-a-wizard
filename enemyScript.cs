using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	public float speed = 7f;
	float direction = -1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed * direction, GetComponent<Rigidbody2D>().velocity.y);
		transform.localScale = new Vector3 ( direction*5, 5, 0);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "barrel") {
			direction *= -1f;
		}
	}
}
