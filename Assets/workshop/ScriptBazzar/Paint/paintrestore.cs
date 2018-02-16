using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paintrestore : MonoBehaviour {

	//public Button Brushimage;
	public static bool Brushbool = false;
	public static bool AllCleanbool = false;
	public static int Dustint = 0;
	public Text dirtyText;

	// Use this for initialization
	void Start () {
		Dustint = 0;
		AllCleanbool = false;
	}
	
	// Update is called once per frame
	void Update () {
		dirtyText.text = "Dirt" + Dustint.ToString();
		//if (AllCleanbool == true) {
			
		//}
	}

	public void Brush (){
		Brushbool = true;
	}
}
