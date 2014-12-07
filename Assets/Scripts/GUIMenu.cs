using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

	void OnMouseDown(){
		if (this.gameObject.name == "Start") {
			Application.LoadLevel("Escena1");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
