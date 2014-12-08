using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {

	public bool p;
	public RaycastHit2D hit;
	public ControladorPersonaje scrptCP;
	public GameObject player; 
	// Use this for initialization
	void Start () {
		p = false;
		scrptCP = player.GetComponent ("ControladorPersonaje") as ControladorPersonaje;
	}


	// Update is called once per frame
	void Update () {
		//Detectamos que los rayos estan en contacto con el personaje (ya sea copia u original)
		// para marcar el boton como pulsado
		if (scrptCP.girado==false) {
						Debug.DrawLine (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y + 0.2f));
						p = Physics2D.Linecast (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y + 0.2f), 1 << 9); 
		} else {

				Debug.DrawLine (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y - 0.2f));
				p = Physics2D.Linecast (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (this.transform.position.x, this.transform.position.y - 0.2f), 1 << 9); 
		}
	}
}
