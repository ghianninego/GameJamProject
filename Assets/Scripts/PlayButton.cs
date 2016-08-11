/* PlayButton.cs
 * Author: Ghiannine Go
 * 
 * This script is used when playing the game
 * 
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	/* This function will fire once the play button is clicked. It will lead to the Main Game scene.
	 * 
	 * param: none
	 * return: none
	 * */
	public void OnClick(){
		SceneManager.LoadScene (1);
	}
}
