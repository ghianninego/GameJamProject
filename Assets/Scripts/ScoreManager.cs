/* ScoreManager.cs
 * Author: Ghiannine Go
 * 
 * This script manages the score that the player must meet in order to pass the level, as well as the scores
 * that will lead them to one to three hearts.
 * 
 * */

using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance = null;

	#region variables
	public float heartOne = 0.5f;
	public float heartTwo = 0.75f;
	public float heartThree = 0.85f;

	public UISprite heartOneObj;
	public UISprite heartTwoObj;
	public UISprite heartThreeObj;
	public UILabel totalScore;
	public UILabel timesUpLabel;
	#endregion

	#region MonoBehaviour
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
		
	}
	#endregion

	public void ShowScore(float score) {
		totalScore.text = (score*100) + "%";

		if (score > heartOne) {
			heartOneObj.color = Color.white;
			timesUpLabel.text = "OPERATION SUCCESS";
		}
		else {
			timesUpLabel.text = "OPERATION FAILED";
		}
		if (score > heartTwo)
			heartTwoObj.color = Color.white;
		if (score > heartThree)
			heartThreeObj.color = Color.white;
	}
}
