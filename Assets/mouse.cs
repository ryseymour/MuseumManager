using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)){
			Cursor.visible = !Cursor.visible;
			Screen.lockCursor = !Screen.lockCursor;
	}
}
}