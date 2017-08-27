using UnityEngine;
using System.Collections;

public class DialogModel : MonoBehaviour {

	public string dialogue = "";
	public float time = 0f;	

	void OnTriggerEnter2D(Collider2D target ) {
		if (target.gameObject.tag == "Player") {
			target.GetComponent<PlayerDialouges> ().setDialogueText (dialogue, gameObject, time);
		}
	}	

}
