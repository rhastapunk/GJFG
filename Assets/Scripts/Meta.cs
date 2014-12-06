using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meta : MonoBehaviour {

	public bool abierto;
	public SpriteRenderer SR;
	public Sprite red;
	public Sprite green;
	public List<GameObject> botones;
	public MecanicaBoton scrptBoton;


	void Start () {


	}

	void Update () {
		print (abierto);
		abierto = true;
		//Cambia la meta de abierto a cerrado y viceversa.
		//Si la meta esta abierta el personaje podra pasar de nivel.
		foreach (GameObject g in botones) {
			scrptBoton = g.GetComponent("MecanicaBoton") as MecanicaBoton; 
			print(scrptBoton.pulsado);
			if(!scrptBoton.pulsado){
				abierto=false;
			}
		}
		if (abierto) {
			SR.sprite = green;
			this.collider2D.enabled=false;
		} else {
			SR.sprite = red;
			this.collider2D.enabled=true;
		}
	
	}
}
