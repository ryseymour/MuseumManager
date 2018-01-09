using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exhibitplace : MonoBehaviour {

	public Transform artifact1Prefab;

	public Transform spawnPoint;

	public Renderer rend;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){
		if (ArtifactPlace.confirmbool == true) {
			if (ArtifactPlace.exh == 1){
				if(ArtifactPlace.artifactint ==1){
					Instantiate (artifact1Prefab, spawnPoint.position, spawnPoint.rotation);
					rend.enabled = false;
				}
			}
			else{
				return;
			}
		} else {
			return;
		}
}
}
