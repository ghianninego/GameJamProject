using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public GameObject PauseMenu;


	public void onClick()
	{
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
