using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class farmingscript : MonoBehaviour {
	public GameObject test;
	public Canvas canvaTop;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){
		test.gameObject.SetActive (true);
		//canvaTop = this.gameObject.GetComponent<Canvas> ();
		//canvaTop.gameObject.SetActive (true);
	}
}
