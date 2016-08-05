using UnityEngine;
using System.Collections;

public class PatientScript : MonoBehaviour {

	//time a new patient appears
	public float timeAppear = 5f;
	private int patienceLevel;
	private GameObject patient;
	private bool served = false;

	void Start () {
		patienceLevel = PlayerManager.Instance.setPatienceLevel (gameObject.tag);
		Debug.Log (patienceLevel);
		StartCoroutine("NotYetServed");
	}

	void Update () {
	}

	void Served() {
		served = true;
		GameManager.Instance.SetScore (patienceLevel);
	}

	IEnumerator NotYetServed() {
		while (served == false) {
			yield return new WaitForSeconds (1.0f);
			patienceLevel -= 1;
			if (patienceLevel == 0) {
				Destroy (gameObject);
				break;
			}
			Debug.Log ("--" + patienceLevel);
		}
				
	}

}
