using UnityEngine;
using System.Collections;

public class ControlGeneral : MonoBehaviour {

	public bool gravity;
	public GameObject player;

	//Funcion para que la gravedad sea hacia arriba
	void CambioGravedad(){
		if (gravity) {
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


		//Seguimiento del personaje por parte de la camara
		//Bordes de la camara
		if (player.transform.position.x >= -7 && player.transform.position.x <= 7) {
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
		if(Input.GetKeyDown(KeyCode.G)){
			CambioGravedad();
		}
	}
}
