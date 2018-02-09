using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

	bool canPlayParticles = false;
	float timeWaiting = 0.5f;
	[SerializeField]
	GameObject particles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(canPlayParticles){
			Vector3 point = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0,1),Random.Range(0,1),Random.Range(0,1)));
			GameObject particlesInstantiate = Instantiate (particles, point, particles.transform.rotation);
			Destroy (particlesInstantiate,4);
			StartCoroutine (ParticlesTime());
		}
	}

	IEnumerator ParticlesTime(){
		canPlayParticles = false;
		yield return new WaitForSeconds (timeWaiting);
		canPlayParticles = true;
	}
}
