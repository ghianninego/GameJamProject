using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance = null;

	public float totalTime = 40f;
	public UILabel timerlabel;
	public GameObject gameOver;

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

	void Start () {
		gameOver.SetActive (false);

		totalScore = 0;
		timer = totalTime+1;
		timerlabel.text = "Time: " + timer+"s";
	}

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			ShowGameOver ();
		}

		timerlabel.text = "Time: " + (int)timer+"s";
	}

	public void SetScore(float x){
		totalScore += x;
	}

	void ShowGameOver() {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}
}