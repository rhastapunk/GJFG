using UnityEngine;
using System.Collections;

public class MovimientoFondo : MonoBehaviour {

	private float camX;

	// Use this for initialization
	void Start () {
		camX = Camera.main.transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
			
		//if(Input.GetKey
			if (this.gameObject.name == "V6") {
				this.transform.position = new Vector3 (this.transform.position.x+(Camera.main.transform.position.x - camX) * -0.5f, this.transform.position.y, transform.position.z);	
				
			}
			if (this.gameObject.name == "V5") {
				this.transform.position = new Vector3 (this.transform.position.x+(Camera.main.transform.position.x - camX) * -0.2f, this.transform.position.y, transform.position.z);	
			}
		//}
}
}