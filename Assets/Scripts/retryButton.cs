using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour {

	public GameObject SuccessPanel;

	public void OnClick(){
		SuccessPanel.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		//Application.LoadLevel(Application.loadedLevel);
		
	}
}
