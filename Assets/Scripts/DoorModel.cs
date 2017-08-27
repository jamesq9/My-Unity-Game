using UnityEngine;
using System.Collections;

public class DoorModel : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;
	public float closeDelay = 0.5f;

	private Collider2D collider;
	private Animator anim;
	private int state = IDLE;

	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnOpenStart() {
		state = OPENING;
	}

	void OnOpenEnd() {
		state = OPEN;
	}

	void OnCloseStart() {
		state = CLOSING;
	}

	void OnCloseEnd() {
		state = IDLE;
	}

	void DisableCollider2D() {
		collider.enabled = false;
	}

	void EnableCollider2D() {
		collider.enabled = true;
	}

	public void Open() {
		anim.SetInteger ("AnimState",1);
	}

	public void Close() {
		StartCoroutine (CloseNow());
	}

	private IEnumerator CloseNow() {
		yield return new WaitForSeconds(closeDelay);
		anim.SetInteger ("AnimState", 2);
	}
}
