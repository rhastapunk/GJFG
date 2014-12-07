using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoCopia : MonoBehaviour {

	public List<float> posicionesCopia;
	public int contador;
	public List<Sprite> sp;
	public SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		contador = 0;
		sr = this.GetComponent ("SpriteRenderer") as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		//Movemos las copias de los personajes en funcion 
		// de las coordenadas guardadas en el vector "Posiciones copias"
		if((contador*7)<posicionesCopia.Count) {
			transform.position = new Vector3 (posicionesCopia[contador * 7], posicionesCopia [contador * 7 + 1], 0);
			Quaternion q = new Quaternion(posicionesCopia[contador*7+2],posicionesCopia[contador*7+3],posicionesCopia[contador*7+4],posicionesCopia[contador*7+5]);

			transform.rotation = q;

			int aux = (int)posicionesCopia[contador*7+6]-1;
			sr.sprite=sp[aux];

			contador++;
		}
	//	print (contador);
		//Reseteamos el contador (para que comiencen desde 0) al pulsar la tecla spacio
		if (Input.GetKeyDown (KeyCode.Space)) {
			contador=0;
		}
	}
}
