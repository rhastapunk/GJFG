using UnityEngine;
using System.Collections;

private bool isGrounded= true;
private bool runRight = true;
public float velocidad = 10f;
public void fuerzaSalto = 100f;


public class ControladorPersonaje : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movimiento = Input.GetAxis ("Horizontal");
		
		
		if (corriendoDerecha) {
			rigidbody2D.velocity = new Vector2 (movimiento * velocidad, rigidbody2D.velocity.y);
		} else if (!corriendoDerecha) {
			rigidbody2D.velocity = new Vector2 (movimiento * velocidad, rigidbody2D.velocity.y);		
		}
		if (movimiento*velocidad > 0 && !corriendoDerecha) {
			GirarPersonaje ();
		} else if (movimiento*velocidad < 0 && corriendoDerecha) {
			GirarPersonaje ();
		}
		
		animator.SetFloat ("VelX", rigidbody2D.velocity.x);
		
		
		
		
	}
	
}
void GirarPersonaje(){
	corriendoDerecha = !corriendoDerecha;
	Vector3 escalar = transform.localScale;
	escalar.x *= -1;
	transform.localScale = escalar;		
}
}
