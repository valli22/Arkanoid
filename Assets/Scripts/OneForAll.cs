using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneForAll : MonoBehaviour {

	float power = 10;

	int type;

	public int totalTypeOfItems = 6;

	// Use this for initialization
	void Start () {
		type = Random.Range (1,totalTypeOfItems+1);
		MeshRenderer ms = transform.GetChild (0).GetComponent<MeshRenderer>();
		switch (type) {

		default:
			Debug.Log("Error");
			break;	
		case 1:
			ms.material.color = Color.black ;
			break;
		case 2:
			ms.material.color = Color.blue ;
			break;
		case 3:
			ms.material.color = Color.grey ;
			break;
		case 4:
			ms.material.color = Color.green;
			break;
		case 5:
			ms.material.color = Color.white ;
			break;
		case 6:
			ms.material.color = Color.red ;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			switch (type) {

			default:
				Debug.Log("Error");
				break;	
			case 1:
				GameManager.instance.BigPaddle ();
				break;
			case 2:
				GameManager.instance.MoreSpeed (power);
				break;
			case 3:
				GameManager.instance.NewBall ();
				break;
			case 4:
				GameManager.instance.LessPaddle ();
				break;
			case 5:
				GameManager.instance.LessSpeed (power);
				break;
			case 6:
				GameManager.instance.Iman ();
				break;
			}
			Destroy (this.gameObject);
		}
		if (other.tag == "Death") {
			Destroy (this.gameObject);
		}
	}

}
