using UnityEngine;
using System.Collections;

public class Meta : MonoBehaviour {

	public bool abierto;
	public SpriteRenderer SR;
	public Sprite red;
	public Sprite green;

	//Cambia la meta de abierto a cerrado y viceversa.
	//Si la meta esta abierta el personaje podra pasar de nivel.
	public void Cambiar(){
		if (abierto) {
			SR.sprite = red;
			abierto = false;
			this.collider2D.enabled=true;
		} else {
			SR.sprite = green;
			abierto=true;
			this.collider2D.enabled=false;
		}
	}
	
	void Start () {
		if (abierto) {
			SR.sprite = green;
			this.collider2D.enabled=false;
		} else {
			SR.sprite = red;
			this.collider2D.enabled=true;
		}

	}

	void Update () {
	
	}
}
