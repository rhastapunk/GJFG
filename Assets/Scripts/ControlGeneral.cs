using UnityEngine;
using System.Collections;

public class ControlGeneral : MonoBehaviour {

	public bool gravity;


	//Funcion para que la gravedad sea hacia arriba
	void CambioGravedad(){
		if (gravity) {
			print ("CAMBIO GRAVEDAD");
			Physics2D.gravity = new Vector2 (0f, 9.81f);
			gravity=false;
		} else {
			Physics2D.gravity = new Vector2(0f,-9.81f);
			gravity=true;
		}
	}

	// Use this for initialization
	void Start () {
		gravity = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Al pulsar la tecla espacio cambia la gravedad de sentido
		if(Input.GetKeyDown(KeyCode.Space)){
			CambioGravedad();
		}
	}
}
