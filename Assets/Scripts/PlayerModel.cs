using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;
	public GameObject checkPoint;

	private Rigidbody2D Body;
	private PlayerController Controller;
	private Animator animator;
	public static bool stopPlayerMovement = false;

	// Use this for initialization
	void Start () {
		Body = GetComponent<Rigidbody2D> ();
		Controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (stopPlayerMovement == true) {
			return;
		}

		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (Body.velocity.x);
		var absVelY = Mathf.Abs (Body.velocity.y);
		var actVelX = Body.velocity.x;
		var actVelY = Body.velocity.y;


		standing = false;
		if (absVelY  < 0.3f) {
			standing = true;
		}



		if (Controller.moving.x != 0) {
			if (absVelX < maxVelocity.x || Controller.moving.x != (actVelX / absVelX)) {
				forceX = (Controller.moving.x * speed);
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}
			if (standing) {
				animator.SetInteger ("AnimState", 1);
			}
		} else { // if ur walking and not flying then stop walking duh.
			animator.SetInteger ("AnimState", 0);
		}

		if (Controller.moving.y > 0) {
			if (absVelY < maxVelocity.y || actVelY <= -maxVelocity.y ) {
				forceY = jetSpeed * Controller.moving.y;
			}
			animator.SetInteger ("AnimState", 2);
		} else if (!standing) {
			animator.SetInteger ("AnimState", 0);
		}


		Body.AddForce (new Vector2 (forceX, forceY));

	}





	public void setCheckPoint(GameObject chk) {

		if (this.checkPoint == null) {
			this.checkPoint = chk;
			checkPoint.GetComponent<CheckPointModel> ().Activate ();
			return;
		}

		if (chk != this.checkPoint) {
			this.checkPoint.GetComponent<CheckPointModel>().DeActivate ();
			this.checkPoint = chk;
			this.checkPoint.GetComponent<CheckPointModel>().Activate ();
		}
	}


	public void DeactivatePlayerMovement() {
		stopPlayerMovement = true;
	}

	public void ActivatePlayerMovement() {
		stopPlayerMovement = false;
	}
}
