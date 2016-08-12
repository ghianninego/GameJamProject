using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance = null;

	#region variables
	public float heartOne = 0.5f;
	public float heartTwo = 075f;
	public float heartThree = 0.85f;

	public GameObject heartOneObj;
	public GameObject heartTwoObj;
	public GameObject heartThreeObj;
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

//		if (score > heartOne) {
//			heartOneObj.GetComponent<SpriteRenderer> ();
//		}
	}
}
