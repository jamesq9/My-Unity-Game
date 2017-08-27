using UnityEngine;
using System.Collections;

public class level0 : MonoBehaviour {

	public string Scene;
	public bool loadLock=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown(0))  && !loadLock) {
			LoadScene ();
		}
	
	}

	void LoadScene() {
		loadLock = true;
		Application.LoadLevel (Scene);
	}
}
