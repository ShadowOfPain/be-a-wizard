using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dieCollider : MonoBehaviour {
	private string scene_name;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "dieCollider") {
			Debug.Log ("Game over"); 
			//	Application.LoadLevel (Application.loadedLevel);
			scene_name = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (scene_name);
		}
	}
}
