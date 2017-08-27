using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public DoorModel door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player")
			door.Open ();
	}


	public void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player")
			door.Close ();
	}


}
