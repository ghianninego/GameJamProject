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
	private Transform character;
	private Transform concern;
	private SpriteRenderer charSprite;
	private SpriteRenderer concSprite;

	private int patienceLevel;
	private int currentPatience;
	private bool served = false;

	private GameObject clickedBed;
	private Ray ray;
	private RaycastHit rayHit;
	private bool wasClicked = false;
	#endregion


	#region MonoBehaviour
	void Awake () {
		character = gameObject.transform.Find ("Character");
		concern = gameObject.transform.Find ("Concern");
		charSprite = character.GetComponent<SpriteRenderer> ();
		concSprite = concern.GetComponent<SpriteRenderer> ();

		SetCharacter ();
		SetConcern ();
	}

	void Start() {
		patienceLevel = PlayerManager.Instance.SetPatienceLevel (charSprite.sprite.name);
		currentPatience = patienceLevel;
		concSprite.color = Color.green;

		StartCoroutine("NotYetServed");
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out rayHit)) {
				clickedBed = rayHit.collider.gameObject;
				string concernId = concSprite.sprite.name.Substring (0, 1);

				if (wasClicked == true) {
					if (clickedBed.tag.Equals (concernId)) {
						this.gameObject.transform.position = clickedBed.transform.position;
						Served ();
					} else if (clickedBed.tag.Equals ("WaitArea")) {
						this.gameObject.transform.position = clickedBed.transform.position;
						Debug.Log ("WAITING AREA");
					} else if (!clickedBed.tag.Equals(concernId) && !clickedBed.tag.Equals("Patient")) {
						Debug.Log ("WRONG FACILITY");
						//do something if wrong bed
					}
				}
			}
		}
	}

	void OnMouseDown() {
		PlayerManager.Instance.selectedSprite = this.gameObject.name;
		wasClicked = true;
		Debug.Log ("Selected: "+PlayerManager.Instance.selectedSprite);
	}
	#endregion

	#region Set Sprites
	private void SetCharacter() {
		int x = Random.Range (0, PlayerManager.Instance.allCharacters.Length);
		charSprite.sprite = PlayerManager.Instance.allCharacters [x];
	}

	private void SetConcern() {
		int x = Random.Range (0, PlayerManager.Instance.allConcerns.Length-1);
		concSprite.sprite = PlayerManager.Instance.allConcerns [x];
	}
	#endregion

	#region patient service
	/* This function is called whenever the selected patient gets served.
	 * It adds the achieved satisfaction rate for that patient to the current score
	 *
	 * param: none
	 * return: none
	 */
	private void Served() {
		served = true;

		StartCoroutine ("Facilitate");
	}

	IEnumerator Facilitate() {
		float addScore = (float)currentPatience / (float)patienceLevel;

		yield return new WaitForSeconds (3f);
		concSprite.sprite = PlayerManager.Instance.allConcerns [4];

		yield return new WaitForSeconds (2f);
		PlayerManager.Instance.RemovePatient (gameObject);
		GameManager.Instance.SetScore (addScore);
	}
		
	/* This function will run while the patient is not yet served.
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
				PlayerManager.Instance.RemovePatient (gameObject);
				break;
			}
		}
	}

	/* This function changes the color of the patient's mood based on his/her patience level.
	 *
	 * param: none
	 * return: none
	 */
	private void ChangeColor() {
		if (currentPatience == (int)(0.25 * patienceLevel))
			concSprite.color = Color.red;
		else if (currentPatience == (int)(0.5 * patienceLevel))
			concSprite.color = Color.magenta;
		else if (currentPatience == (int)(0.75 * patienceLevel))
			concSprite.color = Color.yellow;
	}
	#endregion
}