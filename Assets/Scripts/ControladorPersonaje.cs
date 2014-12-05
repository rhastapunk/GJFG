using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour {
	
	private bool isGrounded;
	private bool runRight;
	public float speed;
	public float jumpForce;
	
	
	
	// Use this for initialization
	void Start () {
		speed = 0.1f;
		isGrounded = false;
		runRight = true;
		jumpForce = 200f;
	}
	void FixedUpdate() {
		
	}
	// Update is called once per frame
	void Update () {
		if (isGrounded) {
			print("EN EL SUELO");
		}
		float movimiento = Input.GetAxis ("Horizontal");
		//moviento derecha e izquierda del personaje
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (speed, 0f, 0f);
			runRight = true;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			runRight = false;
			transform.position -= new Vector3 (speed, 0f, 0f);	
		}
		//control de giro del personaje
		if (!runRight) {
			GirarPersonaje ();
		} else if (runRight) {
			GirarPersonaje ();
		}
		//salto del personaje.
		isGrounded = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y) ,new Vector2(transform.position.x, transform.position.y)-Vector2.up, 1<<8);
		Debug.DrawLine (new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y) - Vector2.up, Color.green);
		if(Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded){

			rigidbody2D.AddForce(Vector2.up*jumpForce);

		}

	}
	void GirarPersonaje(){
		runRight = !runRight;
		Vector3 escalar = transform.localScale;
		escalar.x *= -1;
		transform.localScale = escalar;		
	}
}
