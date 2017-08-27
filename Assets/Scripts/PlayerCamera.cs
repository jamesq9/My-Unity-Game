using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public GameObject target;
	private Transform _t;

	void Awake() {
		GetComponent<Camera> ().orthographicSize = ((Screen.height / 2.0f) / 100);
	}

	// Use this for initialization
	void Start () {
		_t = target.transform;
	}

	// Update is called once per frame
	void Update () {
		if(_t)
		transform.position = new Vector3 (_t.position.x,_t.position.y, transform.position.z);
	}

	public void setNewPlayer(GameObject obj) {
		//obj.GetComponent<PlayerModel> ().DeactivatePlayerMovement ();
		obj.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		StartCoroutine (AddTargetDelay(obj));
	}

	IEnumerator AddTargetDelay(GameObject obj) {
		//obj.GetComponent<PlayerModel> ().DeactivatePlayerMovement ();
		yield return new WaitForSeconds (2f);
		target = obj;
		_t = target.transform;
		obj.GetComponent<PlayerModel> ().ActivatePlayerMovement ();	
	}
}
