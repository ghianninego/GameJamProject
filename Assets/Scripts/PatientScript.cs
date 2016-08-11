/* PatientScript.cs
 * Author: Ghiannine Go
 * 
 * This script manages a certain patient, whether it is a girl, boy or a teacher, and whether if this patient
 * has already been served or not. This will determine the patient's satisfaction rate.
 * 
 * */

using UnityEngine;
using System.Collections;

public class PatientScript : MonoBehaviour {

	#region variables
	public UIWidget concernBG;
	private int patienceLevel;
	private int currentPatience;
	private bool served = false;
	#endregion

	#region MonoBehaviour
	void Start () {
		patienceLevel = PlayerManager.Instance.SetPatienceLevel (gameObject.tag);
		currentPatience = patienceLevel;
		concernBG.color = Color.green;

		StartCoroutine("NotYetServed");
	}
	#endregion


	/* This function is called whenever the selected patient gets served.
	 * It adds the achieved satisfaction rate for that patient to the current score
	 *
	 * param: none
	 * return: none
	 */
	void Served() {
		served = true;
		GameManager.Instance.SetScore (currentPatience/patienceLevel);
	}

	/* This function changes the color of the patient's mood based on his/her patience level.
	 *
	 * param: none
	 * return: none
	 */
	void ChangeColor() {
		if (currentPatience == (int)(0.25 * patienceLevel))
			concernBG.color = Color.red;
		else if (currentPatience == (int)(0.5 * patienceLevel))
			concernBG.color = Color.magenta;
		else if (currentPatience == (int)(0.75 * patienceLevel))
			concernBG.color = Color.yellow;
	}

	/* This function will run until the patient gets served.
	 * The patient will leave once his/her patience reaches 0.
	 *
	 * param: none
	 * return: none
	 */
	IEnumerator NotYetServed() {
		while (served == false) {
			yield return new WaitForSeconds (1.0f);
			currentPatience -= 1;
			ChangeColor ();
			if (currentPatience == 0) {
				Destroy (gameObject);
				GameManager.Instance.removePatients ();
				break;
			}

			Debug.Log ("--" + currentPatience);
		}
				
	}

}
