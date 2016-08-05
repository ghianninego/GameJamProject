using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

	void OnClick() {
		SceneManager.LoadScene (0);
	}
}
