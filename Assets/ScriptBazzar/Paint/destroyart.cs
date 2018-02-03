using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (paintrestore.AllCleanbool == true) {
			Destroy (this.gameObject);
		}
	}
}
