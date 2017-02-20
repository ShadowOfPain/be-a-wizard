using UnityEngine;
using System.Collections;

public class scrollScript : MonoBehaviour {
	private float pos;
	private float pos_dif; 
	float direction = 1f;
	public float speed;

	// Use this for initialization
	void Start () {
		pos = transform.position.y;
		speed = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (pos_dif) > 0.5)
			direction *= -1;		
		transform.position += transform.up * direction * speed * Time.deltaTime;
		pos_dif = transform.position.y - pos; 
	}
}
