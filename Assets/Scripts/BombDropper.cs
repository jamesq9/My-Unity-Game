using UnityEngine;
using System.Collections;

public class BombDropper : MonoBehaviour {

	public float attackDelay = 3f;
	public Bomb bomb;

	// Use this for initialization
	void Start () {
	
		if (attackDelay > 0) {
			StartCoroutine (DropBomb ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DropBomb() {
		yield return new WaitForSeconds (attackDelay);
		Fire ();
		StartCoroutine (DropBomb());
	}

	void Fire() {
		if (bomb) {
			Bomb clone = Instantiate (bomb,transform.position,Quaternion.identity) as Bomb	;	
		}
	}
}
