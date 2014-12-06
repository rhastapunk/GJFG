using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour {

	private bool isGrounded;
	private bool runRight;
	private bool isIdle;
	public float speed;
	public float jumpForce;
	public GameObject detectorI;
	public GameObject detectorD;
	private Animator animator;
	private int aux;
	private Vector3 rotate;

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.name == "PasarNivel") {
		}

	}

	void awake(){
		animator = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		speed = 0.1f;
		isGrounded = true;
		runRight = true;
		jumpForce = 350f;
		animator = GetComponent<Animator> ();
		isIdle = true;
		rotate = transform.localScale;
	}

	// Update is called once per frame
	void Update () {



		/*intentando animator */
		


		/*------------------------------------*/
		//salto del personaje.
		isGrounded = Physics2D.Linecast(new Vector2(detectorI.transform.position.x, detectorI.transform.position.y) ,new Vector2(detectorI.transform.position.x, detectorI.transform.position.y)-Vector2.up, 1<<8);
		//boolean isGround sera true cuando el linecast toque un collaider.
		Debug.DrawLine (new Vector2(detectorI.transform.position.x, detectorI.transform.position.y), new Vector2(detectorI.transform.position.x, detectorI.transform.position.y) - Vector2.up*0.15f, Color.green);
		
		Debug.DrawLine (new Vector2 (detectorD.transform.position.x, detectorD.transform.position.y), new Vector2 (detectorD.transform.position.x, detectorD.transform.position.y) - Vector2.up*0.15f,Color.blue);
		//salto
		if(Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded){
			
			rigidbody2D.AddForce(Vector2.up*jumpForce);
			
		}

		//moviento derecha e izquierda del personaje
		//y control de giro del personaje
		isIdle = true;
				if (Input.GetKey (KeyCode.RightArrow)) { //si presiona tecla izq
						transform.position += new Vector3 (speed, 0f, 0f);
						runRight = true;
						isIdle = false;
						if(transform.localScale.x == -1){
							rotate.x *=-1;
						}
	 
				} else if (Input.GetKey (KeyCode.LeftArrow)) {//si presiona tecla der
						runRight = false;
						transform.position -= new Vector3 (speed, 0f, 0f);
						isIdle = false;

						if(transform.localScale.x == 1){
							rotate.x *=-1;
						}
					
				}
		transform.localScale = rotate;
		//animator
		animator.SetBool ("isGround", isGrounded);
		aux = (int) rigidbody2D.velocity.x;
		animator.SetInteger ("velocidadX", aux);
		animator.SetBool ("isIdle", isIdle);






	}
	
}
