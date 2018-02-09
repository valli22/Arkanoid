using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hp = 1;

	[SerializeField]
	GameObject particles;

	float probability = 0.1f;
	[SerializeField]
	GameObject itemPref;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){

		if (other.transform.tag == "Ball") {
			hp--;
			if(hp<=0){
				GameObject particlesInstance = Instantiate (particles,transform.position,particles.transform.rotation) as GameObject;
				Destroy (particlesInstance,4);
				GameManager.instance.OneLessBrick ();
				float number = Random.Range (0,1);
				if (number <= probability)
					Instantiate (itemPref, transform.position, itemPref.transform.rotation);
				Destroy (this.gameObject);
			}else{
				GetComponent<MeshRenderer> ().material.color = Color.green;
			}
		}

	}
}
