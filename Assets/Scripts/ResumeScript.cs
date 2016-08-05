using UnityEngine;
using System.Collections;

public class ResumeScript : MonoBehaviour {

	public GameObject pauseMenu;
	// Use this for initialization
	public void onClick(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
