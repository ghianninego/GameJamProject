/* PlayerManager.cs
 * Author: Ghiannine Go
 * 
 * This script manages the patience level of each possible patient.
 * 
 * */

using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Instance = null;

	#region variables
	public int boyPatienceLevel = 25;
	public int girlPatienceLevel = 15;
	public int teacherPatienceLevel = 30;

	private bool served;
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
	#endregion

	/* This function sets the patience level of a patient
	 *
	 * param: string
	 * return: int
	 */
	public int SetPatienceLevel(string x) {
		switch (x) {
		case "Boy":
			return boyPatienceLevel;
			break;
		case "Girl":
			return girlPatienceLevel;
			break;
		case "Teacher":
			return teacherPatienceLevel;
			break;
		default:
			return 0;
			break;
		}
	}

}
