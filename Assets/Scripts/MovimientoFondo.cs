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
				this.transform.position = new Vector3 ((Camera.main.transform.position.x - camX) * -0.2f, this.transform.position.y, transform.position.z);	

	}
}