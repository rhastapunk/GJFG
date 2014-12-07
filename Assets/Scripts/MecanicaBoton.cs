using UnityEngine;
using System.Collections;

public class MecanicaBoton : MonoBehaviour {

	public Boton d1;
	public Boton d2;
	public Boton d3;
	public bool pulsado;
	private SpriteRenderer sr;
	public Sprite bPulsado;
	public Sprite bNoPulsado;
	public BoxCollider2D bc;
	// Use this for initialization
	void Start () {
		sr = this.GetComponent ("SpriteRenderer") as SpriteRenderer;
		bc = this.GetComponent ("BoxCollider2D") as BoxCollider2D;
	}
	
	// Update is called once per frame
	void Update () {
		if (pulsado) {
			sr.sprite = bPulsado;
			bc.center = new Vector2(-0.16f,-0.35f);
			bc.size = new Vector2(1.2f,0.55f);
		} else {
			sr.sprite = bNoPulsado;
			bc.center =new Vector2(-0.16f,-0.25f);
			bc.size = new Vector2(1.2f,0.71f);
		}
		if (d1.p || d2.p || d3.p) {
			pulsado = true;
		} else {
			pulsado = false;	
		} 
	}
}
 