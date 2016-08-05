using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance = null;

	public float totalTime = 40f;
	public UILabel timerlabel;
	public GameObject gameOver;
	private float timer;

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
		timer = totalTime+1;
		timerlabel.text = "Time: " + timer+"s";
	}

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			showGameOver ();
		}

		timerlabel.text = "Time: " + (int)timer+"s";
	}

	private void showGameOver() {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}
}
