using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float speed = 0.7f;

	public bool iman = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal")*speed;
		transform.position += new Vector3 (move,0,0);
		transform.position =  new Vector3(Mathf.Clamp (transform.position.x,-8,8),transform.position.y,transform.position.z);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ball") {
			if (iman) {
				other.gameObject.GetComponent<Ball> ().direction = other.gameObject.GetComponent<Rigidbody> ().velocity;
				other.gameObject.GetComponent<Ball> ().power = 1;
				other.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
				other.gameObject.transform.parent = this.transform;
				other.gameObject.GetComponent<Ball> ().isOut = false;
			}
		}
	}

}
