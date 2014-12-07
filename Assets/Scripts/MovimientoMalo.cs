using UnityEngine;
using System.Collections;

public class MovimientoMalo : MonoBehaviour {
	public float minX, maxX, iniX, iniY;
	public bool right,initRight;
	public float moveSpeed;
	Quaternion q;
	// Use this for initialization
	void Start () {
		initRight = right;
		q = new Quaternion ();
		iniX = this.transform.position.x;
		iniY = this.transform.position.y;
		if (right) {
			q = Quaternion.Euler(0f,180f,0f);
			transform.rotation = q;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if(Input.GetKeyDown(KeyCode.Space)){
			this.transform.position=new Vector3(iniX, iniY,0f);
			right=initRight;
		}
	}
	public void Move(){
		if (right) {
			this.transform.position += new Vector3(moveSpeed, 0f,0f);
			if (maxX <= this.transform.position.x) {
				q = Quaternion.Euler(0f,0f,0f);
				transform.rotation = q;
				right = false;
			}
		} else {
			this.transform.position -= new Vector3(moveSpeed, 0f,0f);
			if (minX >= this.transform.position.x) {
				q = Quaternion.Euler(0f,180f,0f);
				transform.rotation = q;
				right = true;
			}
		}
	}
}
