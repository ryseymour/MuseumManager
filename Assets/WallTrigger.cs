using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {
	public GameObject Cam;
	public Transform Startspot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter ()
	{
		Cam.gameObject.transform.position = Startspot.transform.position;
		
	}
}
