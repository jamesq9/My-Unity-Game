using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerDialouges : MonoBehaviour {

	public Text dialouge;
	private bool isDialogueSet = false;


	// Use this for initialization
	void Start () {

		dialouge.text = "";
		//dialouge.GetComponentInChildren<Image> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dialouge != null) {
			Vector3 vect3 = transform.localPosition;
			if(transform.localScale.x < 0)
				vect3.x += -90;
			else 
				vect3.x += 60;
			vect3.y += 60;
			
			dialouge.transform.localPosition = vect3;
		}
	
	}



	public void setDialogueText(string txt, GameObject gameObj,float time) {
		if (!isDialogueSet) {
			isDialogueSet = true;
			dialouge.text = txt;
			//dialouge.GetComponentInChildren<Image> ().enabled  = true;
			Destroy (gameObj);
			StartCoroutine (emptyDialogue(time));
		}
	}

	IEnumerator emptyDialogue(float time) {
		yield return new WaitForSeconds (time);
		isDialogueSet = false;
		dialouge.text = "";
		//dialouge.GetComponentInChildren<Image> ().enabled  = false;

	}
}
