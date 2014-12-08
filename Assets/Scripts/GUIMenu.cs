using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

	void OnMouseDown(){
		if (this.gameObject.name == "Start") {
			Application.LoadLevel("Escena1");
			PlayerPrefs.SetInt("dialog",1);
		}
		if(this.gameObject.name == "Creditos"){
			Application.LoadLevel("Creditos");
		}
	}
	void OnMouseOver(){
		Quaternion q;
		if(this.gameObject.name == "Creditos"){
			q = Quaternion.Euler(0,0,35);
			this.transform.rotation = q;
		}

		if(this.gameObject.name == "Start"){
			q = Quaternion.Euler(0,0,7);
			this.transform.rotation = q;
		}

	}
	void OnMouseExit(){
		Quaternion q;
		if(this.gameObject.name == "Creditos"){
			q = Quaternion.Euler(0,0,0);
			this.transform.rotation = q;
		}
		
		if(this.gameObject.name == "Start"){
			q = Quaternion.Euler(0,0,0);
			this.transform.rotation = q;
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
