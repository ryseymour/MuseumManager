using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPlace : MonoBehaviour {

	public static int artifactint = 0;
	public static int exh = 1;
	public static bool confirmbool = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Artifact1 () {
		artifactint = 1;
	}

	public void Artifact2 () {
		artifactint = 2;
	}

	public void Artifact3 () {
		artifactint = 3;
	}

	public void Exhibithall1 () {
		exh = 1;
	}

	public void PlaceConfirm () {
		confirmbool = true;
        GameObject.Find("Manager").GetComponent<Button>().artifactScore += 1;
	}
}
