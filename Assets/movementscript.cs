﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour {
	public float speed = 1f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, speed*Input.GetAxis ("Vertical") * Time.deltaTime);

	}
}
