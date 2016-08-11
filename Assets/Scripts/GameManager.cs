/* GameManager.cs
 * Author: Ghiannine Go and Jacob Vertouso
 * 
 * This script manages the overall progression of the game: how many patients are going to be served, how long will the game last,
 * and the overall score of the player.
 * 
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance = null;

	#region variables
	public float totalTime = 60f;
	public int totalPatients = 6;
	public UILabel timerlabel;
	public UILabel patientsLabel;
	public GameObject gameOver;
	public UIProgressBar scoreBar;
	public GameObject somePatient;

	private int myPatients;
	private float timer;
	private float totalScore;
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

	void Start () {
		gameOver.SetActive (false);

		myPatients = totalPatients;
		totalScore = 0;
		timer = totalTime+1;
		timerlabel.text = timer+"s";

		StartCoroutine ("GeneratePatients");
	}

	void Update () {
		GenerateGameTime ();
	}
	#endregion


	/* This function sets the score of the player
	 *
	 * param: float
	 * return: none
	 */
	public void SetScore(float x){
		scoreBar.value += (x/totalPatients);
	}


	/* This function lessens the number of patients that still needs to be served
	 *
	 * param: none
	 * return: none
	 */
	public void removePatients(){
		myPatients -= 1;
		patientsLabel.text = "" + myPatients;
	}


	#region Generation
	/* This function shows and generates the game time
	 *
	 * param: none
	 * return: none
	 */
	private void GenerateGameTime(){
		timer -= Time.deltaTime;

		if (timer <= 0) {
			ShowGameOver ();
		}
		timerlabel.text = "" +(int)timer+"s";
	}

	/* Patients are constantly created until it equals the total patients
	 *
	 * param: none
	 * return: none
	 */
	IEnumerator GeneratePatients(){
		int currentPatient = 0;
		int patientId = 1;


		while (currentPatient < totalPatients) {
			yield return new WaitForSeconds (5f);
			GameObject patient = (GameObject)Instantiate (somePatient);
			patient.name = "patient"+(patientId++);

			patient.transform.position = new Vector3 ((float)(-0.2*patientId), 0.5f, -2);
			currentPatient++;
			Debug.Log (patient.name);
		}
	}
	#endregion


	/* This function shows the game over panel
	 *
	 * param: none
	 * return: none
	 */
	void ShowGameOver() {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}

}