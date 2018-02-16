using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModifierScript : MonoBehaviour {

	// Scale speed variable can be set in Inspector with slider and range from 0.1 to 1
	[Range(0.1f, 1f)]
	public float scaleSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Get Input from C key on keyboard
		if (Input.GetKey (KeyCode.C))

			// Decrease scale in X and Y axes according to scaleSpeed value
			transform.localScale = new Vector3 (transform.localScale.x - 0.1f * scaleSpeed,
												transform.localScale.y - 0.1f * scaleSpeed, 0);

		// Get Input from V key on keyboard
		if (Input.GetKey (KeyCode.V))

			// Increase scale in X and Y axes according to scaleSpeed value
			transform.localScale = new Vector3 (transform.localScale.x + 0.1f * scaleSpeed,
												transform.localScale.y + 0.1f * scaleSpeed, 0);
	}
}
