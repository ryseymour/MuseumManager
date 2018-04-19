using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscript : MonoBehaviour {

	public Art myArt;

	// Use this for initialization
	void Start () {
		
	}
	public void Button0 () {
		Master_Art.RestoreThumbnail = 0;
	}

	public void Button1 (){
		Master_Art.RestoreThumbnail = 1;
	}
	// Update is called once per frame
	void Update () {
		
	}


}
