using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Instance = null;

	public int boyPatienceLevel = 15;
	public int teacherPatienceLevel = 25;
	public int girlPatienceLevel = 10;

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

	public int setPatienceLevel(string x) {
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
