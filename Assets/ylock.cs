﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ylock : MonoBehaviour {
	public Camera C1;
	public float Cpos= 5.48f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pos = new Vector3 (transform.position.x, 5.48f, transform.position.z);
		Mathf.Clamp (transform.position.y, 5.47f, 5.49f);
	}
}