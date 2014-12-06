using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour {

	public bool isGrounded;
	private bool runRight;
	private bool isIdle;
	public float speed;
	public float jumpForce;
	public GameObject detectorI;
	public GameObject detectorD;
	private Animator animator;
	private int aux;
	private Vector3 rotate;
	private bool gravity;
	private bool canJump;
	public float s;
	public bool girando; 

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
		s = 0f;
		isGrounded = true;
		runRight = true;
		jumpForce = 350f;
		animator = GetComponent<Animator> ();
		isIdle = true;
		rotate = transform.localScale;
		gravity = false;
		canJump = true;
		girando = false;
	//	f.rotation = new Vector3 (0f, 0f, 0f);
	//	t.rotation = new Vector3 (0f, 0f, 180f);

	}

	// Update is called once per frame
	void Update () {

		print (Time.deltaTime);

		//intentando controlar gravedad 0

		if (Input.GetKeyDown (KeyCode.G)) {
						girando = true;
		}
		if (girando)
		{
			Quaternion from;
			Quaternion to;
			from = Quaternion.Euler (0, 0, 0);
			to = Quaternion.Euler (0, 0, 180);
			s += Time.deltaTime*1.5f;
			transform.rotation = Quaternion.Lerp(from,to,s);
			gravity = true;
		}
		/*------------------------------------*/
		//salto del personaje.
		isGrounded = Physics2D.Linecast(new Vector2(detectorI.transform.position.x, detectorI.transform.position.y) ,
		                                new Vector2(detectorI.transform.position.x, detectorI.transform.position.y)-Vector2.up*0.15f, 1<<8);
		//boolean isGround sera true cuando el linecast toque un collaider.
		Debug.DrawLine (new Vector2(detectorI.transform.position.x, detectorI.transform.position.y), 
		                new Vector2(detectorI.transform.position.x, detectorI.transform.position.y) - Vector2.up*0.15f, Color.green);
		
		Debug.DrawLine (new Vector2 (detectorD.transform.position.x, detectorD.transform.position.y), 
		                new Vector2 (detectorD.transform.position.x, detectorD.transform.position.y) - Vector2.up*0.15f,Color.blue);
		//salto
		if(Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded && canJump){

			canJump = false;
			StartCoroutine("reactiveJump");
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
	IEnumerator reactiveJump(){
		yield return(new WaitForSeconds (0.2f));
		canJump = true;
	}
}
