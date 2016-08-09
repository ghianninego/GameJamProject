using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	}
}
