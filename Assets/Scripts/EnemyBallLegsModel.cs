using UnityEngine;
using System.Collections;

public class EnemyBallLegsModel : MonoBehaviour {
	public float speedx = 50f;
	public float speedy = 350f;
	public Transform sightEndWall,seightEndPlatform;
	private bool collision;

	private Rigidbody2D body;
	private Animator anim;
	private float distanceToGround;
	// Use this for initialization

	private float Last_x = 0 ;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		distanceToGround = GetComponent<Collider2D> ().bounds.extents.y;
		//anim = GetComponent<Animator> ();
	}



	// Update is called once per frame
	void FixedUpdate () {
		var absVelY = Mathf.Abs (body.velocity.y);
		var absVelX = Mathf.Abs (body.velocity.x);


		//print (absVelY+" "+transform.localScale.x+" "+transform.localScale.y);
		if (absVelY == 0f && absVelX == 0f) {

			if( (Last_x != 0) && (Mathf.Abs (Last_x-transform.position.x) <= 0.1f) ) {
				this.transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);
			}

			Last_x = transform.position.x;


			collision = Physics2D.Linecast (transform.position, sightEndWall.position, 1 << LayerMask.NameToLayer("Solid"));
			Debug.DrawLine (transform.position, sightEndWall.position,Color.green);

			if (collision == true) {
				print ("Wall Collision " + collision);
				this.transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);
			} else {
				collision = Physics2D.Linecast (transform.position, seightEndPlatform.position, 1 << LayerMask.NameToLayer ("Solid"));
				Debug.DrawLine (transform.position, seightEndPlatform.position, Color.blue);
				if (collision == false) {
					this.transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);
					print ("Platform Collision " + collision);

				}
			}
			body.AddForce (new Vector2 (speedx * this.transform.localScale.x, this.transform.localScale.y * speedy));
		} 
	}



}
