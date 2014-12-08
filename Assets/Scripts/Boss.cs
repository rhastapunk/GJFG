using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Acido") {
			PlayerPrefs.SetInt("dialog", 1);
			Application.LoadLevel("Escena12");
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
