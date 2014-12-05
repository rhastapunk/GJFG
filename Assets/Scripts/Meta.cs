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
		} else {
			SR.sprite = green;
			abierto=true;
		}
	}
	
	void Start () {
		abierto = false;
	}

	void Update () {
	
	}
}
