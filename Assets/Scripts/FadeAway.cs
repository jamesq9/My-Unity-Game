using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {

	private SpriteRenderer renderer;
	private Color start;
	private Color end;
	private float t = 0.0f;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		start = renderer.color;
		end = new Color (start.r, start.g, start.b, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		renderer.material.color = Color.Lerp (start, end, t / 2);

		if (renderer.material.color.a <= 0) {
			Destroy (gameObject);	
		}
	}
}
