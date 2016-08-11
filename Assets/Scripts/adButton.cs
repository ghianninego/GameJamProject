using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class adButton : MonoBehaviour {

	public void onClick(){
		SceneManager.LoadScene (2);
	}

}
