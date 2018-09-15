using UnityEngine;
using System.Collections;

public class stageManager : MonoBehaviour {

	void Start() {
		Time.timeScale = 1;
	}
	public void LoadLevel (string name) {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest () {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}


}
