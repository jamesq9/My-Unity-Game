using UnityEngine;
using System.Collections;

public class EnableDisableToogle : MonoBehaviour {

	public bool forceToogleEnable = false;
	public bool DefValue = true;
	public GameObject targetGameObject;

	public void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if (forceToogleEnable = true) {
				targetGameObject.SetActive (DefValue);
			} else {
				targetGameObject.SetActive (!targetGameObject.activeSelf); 
			}		
		}

	}

}
