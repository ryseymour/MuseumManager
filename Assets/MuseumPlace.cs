using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumPlace : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		guestviewmove.ModelOn = true;
		TransC1.TransC1sw = true;
		//CameraMove.lerpc1 = true;
	}
	
	// Update is called once per frame
	void Update () {
		TransC1.TransC1sw = true;
	}
}
