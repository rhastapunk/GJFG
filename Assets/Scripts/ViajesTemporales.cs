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
	public ControladorPersonaje scrptPJ;
	SpriteRenderer sp;
	public int nTravels;


	void Start () {
		contador = 0;
		posiciones = new List<float>();
		scrptPJ = player.GetComponent ("ControladorPersonaje") as ControladorPersonaje;
		sp = player.GetComponent ("SpriteRenderer") as SpriteRenderer;
	}

	void Update () {
		//Añadimos las coordenadas actuales x e y al vector posiciones
		auxI = (contador*2)+1;
		posiciones.Add(player.transform.position.x);
		posiciones.Add(player.transform.position.y);

		posiciones.Add (player.transform.rotation.x);
		posiciones.Add (player.transform.rotation.y);
		posiciones.Add (player.transform.rotation.z);
		posiciones.Add (player.transform.rotation.w);

		string aux1 = sp.sprite.name;
		float aux2 = float.Parse (aux1);

		posiciones.Add (aux2);
		contador++;

		if (Input.GetKeyDown (KeyCode.Space) && scrptPJ.isGrounded ) {
			if(nTravels>0){
				//Crea una copia y le asigna las coordenadas de posiciones
				auxCopia =Instantiate(copia,new Vector3(posiciones[0],posiciones[1], 0), Quaternion.identity) as GameObject;
				scrptCopia = auxCopia.GetComponent("MovimientoCopia") as MovimientoCopia;
				scrptCopia.posicionesCopia=posiciones;
				scrptCopia.player=player;
				contador=0;
				player.transform.position=new Vector3(posiciones[0], posiciones[1], 0);
				posiciones= new List<float>();
				Physics2D.gravity = new Vector2 (0f, -9.81f);
				scrptPJ.girado = false;
				player.transform.rotation = Quaternion.Euler (0, 0, 0);
				nTravels--;

			}
		}
	}
} 
