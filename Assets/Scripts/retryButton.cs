using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour {

	public GameObject SuccessPanel;

	public void onClick(){
		SuccessPanel.SetActive (false);
		SceneManager.LoadScene (1);
		//Application.LoadLevel(Application.loadedLevel);
		
	}
}
