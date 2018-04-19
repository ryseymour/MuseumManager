using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePlace : MonoBehaviour {

	public static int artifactRestoreint = 0;
	public static bool confirmcleanbool = false;

	// Use this for initialization
	void Start () {
		artifactRestoreint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Artifact1 () {
		artifactRestoreint = 1;
	}

	public void Artifact2 () {
		artifactRestoreint = 2;
	}

	public void Artifact3 () {
		artifactRestoreint = 3;
	}
		

	public void PlaceConfirm () {
		confirmcleanbool = true;
        //GameObject.Find("Manager").GetComponent<Button>().artifactScore += 1;
	}
}
