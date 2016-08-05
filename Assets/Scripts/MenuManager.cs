using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public static MenuManager Instance = null;

	public GameObject gameOver;
	public GameObject pauseMenu;


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

	void showGameOver() {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}
}
