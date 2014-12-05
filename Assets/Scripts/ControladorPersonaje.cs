using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour {
	
	private bool isGrounded= true;
	private bool runRight = true;
	public float speed = 10f;
	public float jumpForce = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movimiento = Input.GetAxis ("Horizontal");
		
		
		if (runRight) {
			rigidbody2D.velocity = new Vector2 (movimiento * speed, rigidbody2D.velocity.y);
		} else if (!runRight) {
			rigidbody2D.velocity = new Vector2 (movimiento * speed, rigidbody2D.velocity.y);		
		}
		if (movimiento*speed > 0 && !runRight) {
			GirarPersonaje ();
		} else if (movimiento*speed < 0 && runRight) {
			GirarPersonaje ();
		}

		
		
		
		
	}
	

	void GirarPersonaje(){
		runRight = !runRight;
		Vector3 escalar = transform.localScale;
		escalar.x *= -1;
		transform.localScale = escalar;		
	}
}
