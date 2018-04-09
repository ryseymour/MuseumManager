using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnonCollection : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Master_Art.TurnOnCol == true) {
			transform.GetChild (0).gameObject.SetActive (true);
		}

		if (Master_Art.TurnOnCol == false) {
			transform.GetChild (0).gameObject.SetActive (false);
		}
	}
}
