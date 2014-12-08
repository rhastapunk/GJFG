using UnityEngine;
using System.Collections;


public class ControladorPersonaje : MonoBehaviour { 


	public bool isGrounded;
	private bool isIdle;
	public float speed;
	public float jumpForce;
	public GameObject detectorI;
	public GameObject detectorD;
	private Animator animator;
	private Quaternion rotate;
	private bool canJump;
	public float s;
	public bool girado; 
	public bool canUseGravity;


	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.name == "PasarNivel") {
			string auxS = Application.loadedLevelName.Substring(6);
			float auxF= (float)double.Parse(auxS);
			auxF+=1f;
			Application.LoadLevel("Escena"+auxF);
		}

	}

	void awake(){
		animator = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {

		isGrounded = true;
		jumpForce = 500f;
		animator = GetComponent<Animator> ();
		isIdle = true;
		rotate = new Quaternion();
		canJump = true;
		speed = 0.1f;

	}

	// Update is called once per frame
	void Update () {
		print ("Escena"+Application.loadedLevelName.Substring(6));

		//intentando controlar gravedad
		if ((Input.GetKeyDown (KeyCode.G)) && canUseGravity) {
			girado = true;
		}
		if (girado) {
				Quaternion from;
				Quaternion to;
				from = Quaternion.Euler (0, 0, 0);
				to = Quaternion.Euler (0, 0, 180);
				s += Time.deltaTime * 1.5f;
				transform.rotation = Quaternion.Lerp (from, to, s);
				if(s>1){
				transform.rotation = Quaternion.Euler (0,180,180);
				}
		} 
		/*------------------------------------*/
		//salto del personaje.
		if(girado){
			isGrounded = (Physics2D.Linecast(new Vector2(detectorI.transform.position.x,
			                                                       detectorI.transform.position.y) ,
			                                           new Vector2(detectorI.transform.position.x, 
			            detectorI.transform.position.y)+Vector2.up*0.15f, 1<<8) ||
				Physics2D.Linecast(new Vector2(detectorD.transform.position.x,
			                                 detectorD.transform.position.y) ,
			                       new Vector2(detectorD.transform.position.x, 
			            detectorD.transform.position.y)+Vector2.up*0.15f, 1<<8));
		}

		else{
			isGrounded = (Physics2D.Linecast(new Vector2(detectorI.transform.position.x,
			                                             detectorI.transform.position.y) ,
			                                 new Vector2(detectorI.transform.position.x, 
			            detectorI.transform.position.y)-Vector2.up*0.15f, 1<<8) ||
			              Physics2D.Linecast(new Vector2(detectorD.transform.position.x,
			                               detectorD.transform.position.y) ,
			                   new Vector2(detectorD.transform.position.x, 
			            detectorD.transform.position.y)-Vector2.up*0.15f, 1<<8));
		}

		//boolean isGround sera true cuando el linecast toque un collaider.
		Debug.DrawLine (new Vector2(detectorI.transform.position.x,
		                            detectorI.transform.position.y), 
		                new Vector2(detectorI.transform.position.x,
		            detectorI.transform.position.y) - Vector2.up*0.15f, Color.green);
		
		Debug.DrawLine (new Vector2 (detectorD.transform.position.x, 
		                             detectorD.transform.position.y), 
		                new Vector2 (detectorD.transform.position.x,
		             detectorD.transform.position.y) - Vector2.up*0.15f,Color.blue);
		//salto
		if(Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded && canJump){
			if (girado){
			canJump = false;
			StartCoroutine("reactiveJump");
				
			rigidbody2D.AddForce(-Vector2.up*jumpForce);

			}else{
			canJump = false;
			StartCoroutine("reactiveJump");

			rigidbody2D.AddForce(Vector2.up*jumpForce);
			}
		}
	
		//moviento derecha e izquierda del personaje
		//y control de giro del personaje
		isIdle = true;
				if (Input.GetKey (KeyCode.RightArrow)) { //si presiona tecla izq
						transform.position += new Vector3 (speed, 0f, 0f);
						isIdle = false;

						
							if(girado){
								rotate = Quaternion.Euler(0f,180f,180f);
							}else{
								rotate = Quaternion.Euler(0f,0f,0f);
							}
							transform.rotation = rotate;
						
	 
				} else if (Input.GetKey (KeyCode.LeftArrow)) {//si presiona tecla der
						transform.position -= new Vector3 (speed, 0f, 0f);
						isIdle = false;
							

							if(girado){
								rotate = Quaternion.Euler(0f,0f,180f);
							}else{
								rotate = Quaternion.Euler(0f,180f,0f);
							}
							transform.rotation = rotate;
				}
					 
				

		//animator
		animator.SetBool ("isGround", isGrounded);
		animator.SetBool ("isIdle", isIdle);
	}

	IEnumerator reactiveJump(){
		yield return(new WaitForSeconds (0.2f));
		canJump = true;
	}

}
