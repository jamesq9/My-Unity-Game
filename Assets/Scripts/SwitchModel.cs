using UnityEngine;
using System.Collections;

public class SwitchModel : MonoBehaviour {

	private Animator anim;
	private int colliders = 0;
	public DoorModel[] doors;
	public bool ShowGizmos;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		colliders = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (target.gameObject.tag == "BodyPart")
			return;

		if (colliders == 0) {

			colliders++;
			anim.SetInteger ("AnimState", 1);
			foreach (DoorModel door in doors) {
				if (door != null) {
					door.Open ();
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D target) {

		if (target.gameObject.tag == "BodyPart")
			return;
		
		colliders--;
		if (colliders < 0)
			colliders = 0;
		if (colliders == 0) {
			anim.SetInteger ("AnimState", 2);
			foreach (DoorModel door in doors) {
				if (door != null) {
					door.Close ();
				}
			}
		}
	}

	void OnDrawGizmos() {
		if (ShowGizmos) {
			Gizmos.color = Color.white;
			foreach (DoorModel door in doors) {
				if (door != null) {
					Gizmos.DrawLine (transform.position, door.transform.position);
				}
			}
		}
	}
}
