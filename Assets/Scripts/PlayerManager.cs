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

	[HideInInspector]public Sprite[] allConcerns;
	[HideInInspector]public Sprite[] allCharacters;

	[HideInInspector]public string selectedSprite;
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

	void Awake() {
		allConcerns = Resources.LoadAll<Sprite> ("Concerns");
		allCharacters = Resources.LoadAll<Sprite> ("Characters");
	}
	#endregion

	/* This function sets the patience level of a patient
	 *
	 * param: string
	 * return: int
	 */
	public int SetPatienceLevel(string x) {
		if (x.Contains("boy"))
			return boyPatienceLevel;
		else if (x.Contains("girl"))
			return girlPatienceLevel;
		else
			return teacherPatienceLevel;
	}

	public void RemovePatient(gameObject obj) {
		Destroy (obj);
		GameManager.Instance.removePatients ();
	}

}