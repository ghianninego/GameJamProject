using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour {

	public GameObject SuccessPanel;

	public void onClick(){
		SuccessPanel.SetActive (false);
		Time.timeScale = 1;
		SceneManager.LoadScene (1);

		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		//Application.LoadLevel(Application.loadedLevel);
		
	}
}
