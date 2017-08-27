using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStickController : MonoBehaviour {

	public PlayerController controller;

	// Horizontal
	public void StopHorizontalMovement() {
		controller.setHorizontalMovement (0);
	}

	public void MoveRight() {
		controller.setHorizontalMovement (1);
	}
		
	public void MoveLeft() {
		controller.setHorizontalMovement (-1);
	}

	// Vertical 
	public void StopVerticalMovement() {
		controller.setVirtialMovement (-1);
	}

	public void MoveUp() {
		controller.setVirtialMovement (1);
	}
		

	void Update() {
		if (controller == null) {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				controller = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
			}
		}
	}

}
