using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour {
	
	private bool isGrounded= true;
	private bool runRight = true;
	public float speed;
	public float jumpForce;

	// Use this for initialization
	void Start () {
		speed = 0.1f;
		isGrounded = true;
		runRight = true;
		jumpForce = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		float movimiento = Input.GetAxis ("Horizontal");
		if(	Input.GetKey(KeyCode.RightArrow)){
			transform.position += new Vector3(speed,0f,0f);
			runRight = true;
		}
		if(	Input.GetKey(KeyCode.LeftArrow)){
			runRight = false;
			transform.position -= new Vector3(speed,0f,0f);	
		}
		if (!runRight) {
			GirarPersonaje ();
		}else if (runRight) {
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
