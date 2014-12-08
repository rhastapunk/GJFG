using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public GameObject other;
	public Portal scrptOther;
	// Use this for initialization
	void Start () {
		scrptOther =  other.GetComponent("Portal") as Portal;
	}
	IEnumerator reactivar(){
		yield return new WaitForSeconds (1);
		gameObject.collider2D.enabled = true;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			other.gameObject.collider2D.enabled=false;
			col.gameObject.transform.position=other.transform.position;
			scrptOther.reactivar();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
