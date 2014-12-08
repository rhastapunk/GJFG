using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3(0,0.01f,0);
		if((Input.GetKeyDown(KeyCode.Escape)||(Input.GetKeyDown(KeyCode.Space)))){
			Application.LoadLevel("MenuPrincipal");

		}
	}

}
