using UnityEngine;
using System.Collections;

public class Trampolin : MonoBehaviour {
	public Vector2 fuerza;
	public bool izquierda;
	public SpriteRenderer sr;
	public Sprite cargado;
	public Sprite liberado;
	// Use this for initialization
	void Start () {
		sr = this.GetComponent ("SpriteRenderer") as SpriteRenderer;
	}

	IEnumerator cargar(){
		yield return new WaitForSeconds (0.2f);
		sr.sprite = cargado;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if(izquierda){
				col.gameObject.rigidbody2D.velocity=Vector2.zero;
				col.gameObject.rigidbody2D.AddForce(new Vector2(fuerza.x*-1, fuerza.y), ForceMode2D.Impulse);
				sr.sprite=liberado;
				StartCoroutine("cargar");
			}
			else{
				col.gameObject.rigidbody2D.velocity=Vector2.zero;
				col.gameObject.rigidbody2D.AddForce(fuerza,ForceMode2D.Impulse);
				sr.sprite=liberado;
				StartCoroutine("cargar");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
