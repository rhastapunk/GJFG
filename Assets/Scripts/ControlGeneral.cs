using UnityEngine;
using System.Collections;

public class ControlGeneral : MonoBehaviour {

	public bool gravity;
	public GameObject player; 
	public bool canUseGravity;
	public int maxX, minX;


	//Funcion para que la gravedad sea hacia arriba
	void CambioGravedad(){
		if (gravity) {
			Physics2D.gravity = new Vector2 (0f, 9.81f);
			gravity=false;
		}
	}

	// Use this for initialization
	void Start () { 

		gravity = true;
		if (maxX == 0) {
			maxX = 7;
			minX = -15;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			gravity = true;

		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Physics2D.gravity = new Vector2 (0f, -9.81f);
			Application.LoadLevel(Application.loadedLevel);
			
		}
		//Seguimiento del personaje por parte de la camara
		//Bordes de la camara
		if (player.transform.position.x >= minX && player.transform.position.x <= maxX) {
			if(Mathf.Abs(transform.position.x - player.transform.position.x)>=2){
				if(player.transform.position.x-transform.position.x<0){
					this.transform.position=new Vector3(player.transform.position.x+2,0f,-10f);
				}
				else{
					this.transform.position=new Vector3(player.transform.position.x-2,0f,-10f);
				}
			}
		}

		//Al pulsar la tecla espacio cambia la gravedad de sentido
		if(Input.GetKeyDown(KeyCode.G) && canUseGravity){
			CambioGravedad();
		}
	/*	if (Input.GetKeyDown (KeyCode.G)) {
				Physics2D.gravity = new Vector2 (0f, -9.81f);
		}*/
	}
}
