using UnityEngine;
using System.Collections;

public class Trampolin : MonoBehaviour {
	public Vector2 fuerza;
	public bool izquierda;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if(izquierda){
				col.gameObject.rigidbody2D.velocity=Vector2.zero;
				col.gameObject.rigidbody2D.AddForce(new Vector2(fuerza.x*-1, fuerza.y), ForceMode2D.Impulse);
			}
			else{
				col.gameObject.rigidbody2D.velocity=Vector2.zero;
				col.gameObject.rigidbody2D.AddForce(fuerza,ForceMode2D.Impulse);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
