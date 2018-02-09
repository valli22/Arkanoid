using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 direction;
	public float power = 20;
	Rigidbody rb;
	public bool isOut = false;
	public bool expulse = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		direction = new Vector3 (0.5f, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.Space) && !isOut) || expulse) {
			rb.isKinematic = false;
			GetComponent<Rigidbody> ().AddForce (direction*power,ForceMode.Impulse);
			transform.parent = null;
			isOut = true;
			expulse = false;
		}
	}
}
