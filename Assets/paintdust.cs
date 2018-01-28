using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class paintdust : MonoBehaviour {
	

	// Use this for initialization
	void Awake () {
		paintrestore.Dustint = 12;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		if (paintrestore.Brushbool == true) {
			paintrestore.Dustint = paintrestore.Dustint - 1;
			if (paintrestore.Dustint == 0) {
				paintrestore.AllCleanbool = true;
			}
			Destroy (gameObject);
		}
	}
}
