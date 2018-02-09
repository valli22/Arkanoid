using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Ball") {
			GameManager.instance.OneLessLife();
			Destroy (other.gameObject);
		}
	}
}
