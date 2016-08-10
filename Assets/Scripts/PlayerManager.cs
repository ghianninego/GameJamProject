using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Instance = null;

	public int boyPatienceLevel = 25;
	public int girlPatienceLevel = 15;
	public int teacherPatienceLevel = 30;

	private bool served;

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
