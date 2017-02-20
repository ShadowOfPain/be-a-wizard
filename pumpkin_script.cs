using UnityEngine;
using System.Collections;

public class pumpkin_script : MonoBehaviour {
	private float pos;
	private float pos_dif; 
	float direction = 1f;
	public float speed;

	void Start () {
		pos = transform.position.y;
		speed = 0.3f;
	}

	void Update () {
		if (Mathf.Abs (pos_dif) > 0.2)
			direction *= -1;		
		transform.position += transform.up * direction * speed * Time.deltaTime;
		pos_dif = transform.position.y - pos; 
	}
}
