using UnityEngine;
using System.Collections;

public class Dialogo : MonoBehaviour {

	public bool hablando;
	public int contador;
	public GameObject dI;
	public GameObject dD;
	// Use this for initialization
	void Start () {
		if (hablando) {
			dI.SetActive(true);
		}
	}
	void CambioDialogo(){
		if (dI.activeSelf) {
			dI.SetActive (false);
			dD.SetActive (true);
		} else {
			dD.SetActive(false);
			dI.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
		if (contador >= 0) {
						if (Input.GetKeyDown (KeyCode.Space)) {
								CambioDialogo ();
								contador--;
						}
				}
		else{
			dI.SetActive (false);
			dD.SetActive (false);
			hablando=false;
		}
	
	}
}
