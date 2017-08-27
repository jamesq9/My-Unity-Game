using UnityEngine;
using System.Collections;

public class CheckPointModel : MonoBehaviour {

	public Sprite Active;
	public Sprite Inactive;
	public float unitsAhead = 0f;

	public void Start() {
		GetComponent<SpriteRenderer> ().sprite = Inactive;
	}

	public void Activate() {
		
		GetComponent<SpriteRenderer> ().sprite = Active;
	}

	public void DeActivate() {
		GetComponent<SpriteRenderer> ().sprite = Inactive;
	}


	void OnTriggerEnter2D(Collider2D target ) {
		if (target.gameObject.tag == "Player") {
			target.GetComponent<PlayerModel> ().setCheckPoint (gameObject);	
		}
	}	





}
