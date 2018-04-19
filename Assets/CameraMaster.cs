using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaster : MonoBehaviour {
	public GameObject Camera1;
	public GameObject Camera2;
	public Camera c2;

	// Use this for initialization
	void Start () {
		Camera1.SetActive (true);
		//Camera2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestoreCamera() {
		Camera1.SetActive (false);
		//Camera2.SetActive (false);
		c2 = Camera2.GetComponent<Camera> ();
		c2.gameObject.SetActive (true);
	}


}
