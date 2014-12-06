using UnityEngine;
using System.Collections;
//AsfASDF
public class Boton : MonoBehaviour {

	public bool p;
	public RaycastHit2D hit;

	// Use this for initialization
	void Start () {
		p = false;
	}

	/*
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			pulsado=true;
		}
	}
	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			pulsado=false;
		}
	}
	*/	
	// Update is called once per frame
	void Update () {
		//Detectamos que los rayos estan en contacto con el personaje (ya sea copia u original)
		// para marcar el boton como pulsado
		Debug.DrawLine (new Vector2 (this.transform.position.x , this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y+0.2f));
		p = Physics2D.Linecast (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y + 0.2f), 1<<9); 
	
	}
}
