using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance = null;

	public float totalTime = 60f;
	public int totalPatients = 6;
	public UILabel timerlabel;
	public UILabel patientsLabel;
	public GameObject gameOver;
	public UIProgressBar scoreBar;

	public GameObject[] patients;
	private float timer;
	private float totalScore;

	void OnEnable() {
		if (Instance == null) {
			Instance = this;
		}
	}

	void OnDisable() {
		if (Instance == this) {
			Instance = null;
		}
	}

	void Start() {
		gameOver.SetActive (false);

		totalScore = 0;
		timer = totalTime+1;
		timerlabel.text = timer+"s";

		StartCoroutine ("GeneratePatients");
	}

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			ShowGameOver ();
		}

		timerlabel.text = "" +(int)timer+"s";
	}

	public void SetScore(float x){
		scoreBar.value += (x/totalPatients);
	}

	public void removePatients(){
		totalPatients -= 1;
		patientsLabel.text = "" + totalPatients;
	}

	void ShowGameOver() {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}

	IEnumerator GeneratePatients(){
		int currentPatients = 0;
		while (currentPatients < totalPatients) {
			int rand = UnityEngine.Random.Range(0, patients.Length);
			yield return new WaitForSeconds (3f);
			GameObject sprite = GameObject.Instantiate(patients[rand]) as GameObject;
			//sprite.transform.position= new Vector3 (-1.8f , 0.3f, 0);
			currentPatients++;
			Debug.Log ("NEW CHARACTER");
		}
	}


}