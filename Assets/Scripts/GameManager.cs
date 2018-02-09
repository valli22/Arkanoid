using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int lifes = 3;

	[SerializeField]
	int brickCount = 20;

	int ballNumber = 1;

	[SerializeField]
	GameObject ballPrefab;

	[SerializeField]
	GameObject player;

	[SerializeField]
	Text lifeHUD;

	[SerializeField]
	GameObject victoryHUD;
	[SerializeField]
	GameObject defeatHUD;

	public static GameManager instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		UpdateHUD ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void UpdateHUD(){
		lifeHUD.text = lifes.ToString();
	}

	void Defeat(){
		defeatHUD.SetActive (true);
		Time.timeScale = 0;
	}

	void Victory(){
		victoryHUD.SetActive (true);
		Time.timeScale = 0;
	}

	public void OneLessBrick(){
		brickCount--;
		if (brickCount <= 0) {
			Victory ();
		}
	}

	public void OneLessLife(){
		if (ballNumber <= 1) {
			lifes--;
			UpdateHUD ();
			if (lifes <= 0) {
				Defeat ();
			} else {
				GameObject newBall = Instantiate (ballPrefab, player.transform.position + new Vector3 (0, 1, 0), ballPrefab.transform.rotation) as GameObject;
				newBall.transform.parent = player.transform;
			}
		} else {
			ballNumber--;
		}
	}

	public void NewBall()
	{
		GameObject newBall = Instantiate (ballPrefab, player.transform.position + new Vector3 (0, 1, 0), ballPrefab.transform.rotation) as GameObject;
		newBall.transform.parent = player.transform;
		newBall.GetComponent<Ball> ().expulse = true;
		ballNumber++;
	}

	public void BigPaddle(){
		if (player.transform.childCount == 0) {
			player.transform.localScale += new Vector3 (1.5f, 0,0);
		} else {
			GameObject[] childs = new GameObject[player.transform.childCount];
			for (int i = 0; i < player.transform.childCount; i++) {
				childs[i] = player.transform.GetChild(i).gameObject;
			}
			foreach (GameObject child in childs) {
				child.transform.parent =null;
			}
			player.transform.localScale += new Vector3 (1.5f, 0,0);
			foreach (GameObject child in childs) {
				child.transform.parent =player.transform;
			}
		}

	}
	public void LessPaddle(){
		if (player.transform.childCount == 0) {
			player.transform.localScale -= new Vector3 (1.5f, 0,0);
		} else {
			GameObject[] childs = new GameObject[player.transform.childCount];
			for (int i = 0; i < player.transform.childCount; i++) {
				childs[i] = player.transform.GetChild(i).gameObject;
			}
			foreach (GameObject child in childs) {
				child.transform.parent =null;
			}
			player.transform.localScale -= new Vector3 (1.5f, 0,0);
			foreach (GameObject child in childs) {
				child.transform.parent =player.transform;
			}
		}
	}

	public void MoreSpeed(float power){
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject ball in balls) {
			Debug.Log (ball);
			ball.GetComponent<Rigidbody> ().velocity += ball.GetComponent<Rigidbody> ().velocity.normalized * power;
		}
	}
	public void LessSpeed(float power){
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject ball in balls) {
			Debug.Log (ball);
			ball.GetComponent<Rigidbody> ().velocity -= ball.GetComponent<Rigidbody> ().velocity.normalized * power;
		}
	}

	public void Iman(){
		player.GetComponent<Paddle> ().iman = true;
	}

	public void _RESTART(){
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void _EXIT(){
		Application.Quit ();
	}

}
