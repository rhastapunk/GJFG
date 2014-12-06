using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViajesTemporales : MonoBehaviour {


	public List<float> posiciones;
	public GameObject player;
	public GameObject copia;
	public GameObject auxCopia;
	public int contador;
	public int auxI;
	public MovimientoCopia scrptCopia;

	void Start () {
		contador = 0;
		posiciones = new List<float>();
	}

	void Update () {
		//Añadimos las coordenadas actuales x e y al vector posiciones
		auxI = (contador*2)+1;
		posiciones.Add(player.transform.position.x);
		posiciones.Add(player.transform.position.y);
		contador++;

		if (Input.GetKeyDown (KeyCode.Space)) {

			//Crea una copia y le asigna las coordenadas de posiciones
			auxCopia =Instantiate(copia,new Vector3(posiciones[0],posiciones[1], 0), Quaternion.identity) as GameObject;
			scrptCopia = auxCopia.GetComponent("MovimientoCopia") as MovimientoCopia;
			scrptCopia.posicionesCopia=posiciones;
			contador=0;
			player.transform.position=new Vector3(posiciones[0], posiciones[1], 0);
			posiciones= new List<float>();
			print ("INSTANCIO");
		}
	}
} 
