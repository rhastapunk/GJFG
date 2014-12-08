using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogo : MonoBehaviour {

	public int hablando;
	public int contador;
	public GameObject dI;
	public GameObject dD;
	public GameObject dDBoss;
	public List<int> personajes;
	public List<Sprite> textos;
	public int pjCont;
	private SpriteRenderer auxSR;
	public GameObject cuadro0;
	public GameObject cuadro1;
	public GameObject cuadro2;
	// Use this for initialization
	void Start () {
		hablando = PlayerPrefs.GetInt("dialog");
		switch (personajes[0]) {
			
		case 0:
			dI.SetActive (true);
			dD.SetActive (false);
			dDBoss.SetActive (false);
			auxSR=cuadro0.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[0];
			break;
			
		case 1:
			dI.SetActive (false);
			dD.SetActive (true);
			dDBoss.SetActive (false);
			auxSR=cuadro1.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[0];
			break;
			
		case 2:
			dI.SetActive (false);
			dD.SetActive (false);
			dDBoss.SetActive (true);
			auxSR=cuadro2.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[0];
			break;
		}
	}
	//Personajes que hablan en el dialogo
	void CambioDialogo(int pj){

		switch (pj) {
			
		case 0:
			dI.SetActive (true);
			dD.SetActive (false);
			dDBoss.SetActive (false);
			auxSR=cuadro0.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[pjCont];
			break;
			
		case 1:
			dI.SetActive (false);
			dD.SetActive (true);
			dDBoss.SetActive (false);
			auxSR=cuadro1.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[pjCont];
			break;
			
		case 2:
			dI.SetActive (false);
			dD.SetActive (false);
			dDBoss.SetActive (true);
			auxSR=cuadro2.GetComponent("SpriteRenderer") as SpriteRenderer;
			auxSR.sprite=textos[pjCont];
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		print (contador);
		if (contador == 0) {

			contador--;
		}

		if(contador<0){
			if (Input.GetKeyDown (KeyCode.Space)) {
				PlayerPrefs.SetInt ("dialog", 0);
				Application.LoadLevel (Application.loadedLevel);
				dI.SetActive (false);	
				dD.SetActive (false);
				dDBoss.SetActive (false);
				hablando = 0;

			}
			
			
		}

		if (contador > 0) {


			if (hablando == 1) {
				print("ENTRO");
						if (Input.GetKeyDown (KeyCode.Space)) {

								pjCont++;
								CambioDialogo (personajes [pjCont]);
								contador--;
						}
				}
			else{
				if(Application.loadedLevelName=="Escena12"){
					Application.LoadLevel("Creditos");
				}
				dI.SetActive (false);
				dD.SetActive (false);
				dDBoss.SetActive (false);
			}

		} 


		}
	}
