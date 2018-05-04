using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenScript : MonoBehaviour {
	public GameObject HelpScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){
		HelpScreen.SetActive (true);
		Debug.Log ("HelpScreenTest");
	}
}
