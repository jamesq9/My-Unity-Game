using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject bodypart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy") {
			DestroyRoutine ();
		}

	}

	public void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy") {
			DestroyRoutine ();
		}

	}

	public void DestroyRoutine() {


		if (gameObject.tag == "Player") {
			if(gameObject.GetComponent<PlayerModel> ().checkPoint != null) {
				CheckPointModel chk = gameObject.GetComponent<PlayerModel> ().checkPoint.GetComponent<CheckPointModel>();
				var spawnPlace = chk.transform;
				Vector3 vect3 = chk.transform.position;
				vect3.x += chk.unitsAhead;
				//gameObject.GetComponent<PlayerModel> ().DeactivatePlayerMovement ();
				GameObject clone = Instantiate (gameObject,vect3,Quaternion.identity) as GameObject;
				clone.GetComponent<PlayerModel> ().DeactivatePlayerMovement ();
				Camera.main.GetComponent<PlayerCamera> ().setNewPlayer (clone);
			}
		} 

    	Destroy (gameObject);

		var t = transform;
		for (int i = 0; i < sprites.Length; i++) {
			GameObject clone = Instantiate (bodypart,t.position,Quaternion.identity) as GameObject;
			clone.GetComponent<SpriteRenderer> ().sprite = sprites [i];
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.right * Random.Range(-50,50));
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.up * Random.Range(30,50));

		}




		//RestartScene ();

	}

	public void RestartScene () {
		GameObject go = new GameObject ("level0");
		level0 script = go.AddComponent<level0> ();
		script.Scene = Application.loadedLevelName;
	}
}
