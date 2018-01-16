using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exhibitplace : MonoBehaviour {

	public Transform artifact1Prefab;

	public Transform spawnPoint;

	public Renderer rend;

	public GameObject guest2;
	public static int artifactNumber = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find("Canvas").GetComponentInChildren<Donate>().text = 
		//if (donateNow == true) {
			//Donate ();
		//}

	}

	//void Donate () {

	//}

	void OnMouseDown (){
		if (ArtifactPlace.confirmbool == true) {
			if (ArtifactPlace.exh == 1){
				if(ArtifactPlace.artifactint ==1){
					Instantiate (artifact1Prefab, spawnPoint.position, spawnPoint.rotation);
					rend.enabled = false;
					artifactNumber = artifactNumber + 1;
					//gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

					//GuestWaypointMove GuestStay = Guest.GetComponent<GuestWaypointMove> ().guestRepeat = gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

					//GuestStay = guest2.GetComponent<GuestWaypointMove> ().guestRepeat;

					//GuestStay += 1;


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
