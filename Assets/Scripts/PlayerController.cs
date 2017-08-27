using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
	

	public Vector2 moving = new Vector2();
	public bool keyboardTesting = false;

	// Use this for initialization
	void Start () {
		moving.x = moving.y = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (keyboardTesting) {
			moving.x = moving.y = 0;

			if (Input.GetKey ("right")) {
				moving.x = 1;
			} else if (Input.GetKey ("left")) {
				moving.x = -1;	
			} else {
				moving.x = 0;
			}

			if (Input.GetKey ("up")) {
				moving.y = 1;
			} else if (Input.GetKey ("down")) {
				moving.y = -1;	
			} else {
				moving.y = 0;
			}
		}


	}

	public void setHorizontalMovement(int dir) {
		moving.x = dir;
	}

	public void setVirtialMovement(int dir) {
		moving.y = dir;
	}





}
