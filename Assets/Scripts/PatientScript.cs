using UnityEngine;
using System.Collections;

public class PatientScript : MonoBehaviour {

	//time a new patient appears
	public float timeAppear = 5f;
	public UIWidget concernBG;
	private int patienceLevel;
	private int currentPatience;
	private bool served = false;

	void Start () {
		patienceLevel = PlayerManager.Instance.SetPatienceLevel (gameObject.tag);
		currentPatience = patienceLevel;
		concernBG.color = Color.green;

		StartCoroutine("NotYetServed");
	}

	void Served() {
		served = true;
		GameManager.Instance.SetScore (currentPatience/patienceLevel);
	}

	void ChangeColor() {
		if (currentPatience == (int)(0.25 * patienceLevel))
			concernBG.color = Color.red;
		else if (currentPatience == (int)(0.5 * patienceLevel))
			concernBG.color = Color.magenta;
		else if (currentPatience == (int)(0.75 * patienceLevel))
			concernBG.color = Color.yellow;
	}

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
