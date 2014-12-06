using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoCopia : MonoBehaviour {

	public List<float> posicionesCopia;
	public int contador;
	// Use this for initialization
	void Start () {
		contador = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Movemos las copias de los personajes en funcion 
		// de las coordenadas guardadas en el vector "Posiciones copias"
		if((contador*2)<posicionesCopia.Count) {
			transform.position = new Vector3 (posicionesCopia[contador * 2], posicionesCopia [contador * 2 + 1], 0);
			contador++;
		}
		//Reseteamos el contador (para que comiencen desde 0) al pulsar la tecla spacio
		if (Input.GetKeyDown (KeyCode.Space)) {
			contador=0;
		}
	}
}
