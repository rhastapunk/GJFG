using UnityEngine;
using System.Collections;

public class botonFinal : MonoBehaviour {

	public GameObject plataformaFinal;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		print (col.gameObject.name);
		if (col.gameObject.tag == "Player") {
			Destroy(plataformaFinal);
		}

	}
	// Update is called once per frame
	void Update () {


	
	}
}
