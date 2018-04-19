using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void RestoreRepeat () {
		transform.GetChild (0).gameObject.SetActive (true);
		transform.GetChild (1).gameObject.SetActive (true);
		transform.GetChild (2).gameObject.SetActive (true);
		transform.GetChild (3).gameObject.SetActive (true);
		transform.GetChild (4).gameObject.SetActive (true);
		transform.GetChild (5).gameObject.SetActive (true);
		transform.GetChild (6).gameObject.SetActive (true);
	dirtspots RestRep =	this.GetComponentInChildren<dirtspots> ();
		RestRep.RestoreRepeat ();
		//Master_Art.dirtyspots = 7;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
