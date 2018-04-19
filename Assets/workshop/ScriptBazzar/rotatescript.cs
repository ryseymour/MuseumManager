using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatescript : MonoBehaviour {
	public GameObject objectRotate;

	public float rotateSpeed = 3f;
	bool rotateStatus = false;
	// Use this for initialization
	void Start () {
		
	}

	public void RotateYes ()
	{
		if (rotateStatus == false) {
			rotateStatus = true;
		} else {
			rotateStatus = false;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (rotateStatus == true) {
			objectRotate.transform.Rotate (Vector3.up, rotateSpeed * Time.deltaTime);
		}
	}
}
