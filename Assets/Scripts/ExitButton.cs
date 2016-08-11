/* ExitButton.cs
 * Author: Ghiannine Go
 * 
 * This script is used when returning to the Main Menu scene after finishing the game
 * 
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

	/* This function is called whenever the exit button is called. It returns to the Main Menu scene
	 * 
	 * param: none
	 * return: none
	 * */
	public void OnClick() {
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	}
}
