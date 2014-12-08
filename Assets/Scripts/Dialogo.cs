using UnityEngine;
using System.Collections;

public class Dialogo : MonoBehaviour {

	public int hablando;
	public int contador;
	public GameObject dI;
	public GameObject dD;
	// Use this for initialization
	void Start () {
		hablando = PlayerPrefs.GetInt("dialog");
		if (hablando==1) {
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
		if (contador > 0 && hablando==1) {
						if (Input.GetKeyDown (KeyCode.Space)) {
								CambioDialogo ();
								contador--;
						}
					if(contador ==0){
						Application.LoadLevel(Application.loadedLevel);
						PlayerPrefs.SetInt("dialog",0);
						contador--;
					}


				}
		else{
			dI.SetActive (false);
			dD.SetActive (false);
			hablando=0;
			

		}

	
	}
}
