using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restoreinstantiate : MonoBehaviour {
	//This will need to havea  list value!!!
	//public Transform artifact2Prefab;
	public GameObject artifact2Prefab;

	public Transform spawnPoint;

	public Renderer rend;

	public GameObject guest2;
	public static int artifactNumber = 0;
	//public static List<GameObject> artifacts = new List<GameObject>()


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find("Canvas").GetComponentInChildren<Donate>().text = 
		//if (donateNow == true) {
			//Donate ();
		//}
		if (RestorePlace.confirmcleanbool == true) {

			RestorePlaceInstance ();

	}
		if (paintrestore.AllCleanbool == true) {
			RestoreComplete ();
		}

	//void Donate () {

	//}


}

	public void RestorePlaceInstance () {
		if(RestorePlace.artifactRestoreint ==2){
			Instantiate (artifact2Prefab, spawnPoint.position, spawnPoint.rotation);
			rend.enabled = false;
			RestorePlace.artifactRestoreint = 0;
			RestorePlace.confirmcleanbool = false;
			//artifactNumber = artifactNumber + 1;
			//gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

			//GuestWaypointMove GuestStay = Guest.GetComponent<GuestWaypointMove> ().guestRepeat = gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

			//GuestStay = guest2.GetComponent<GuestWaypointMove> ().guestRepeat;

			//GuestStay += 1;


		}
	}

	public void RestoreComplete () {
		rend.enabled = true;
		//RestorePlace.artifactRestoreint = 0;
		//RestorePlace.confirmcleanbool = false;
		//Destroy(Instantiate(artifact2Prefab, spawnPoint.position, spawnPoint.rotation));
		//Object.Destroy(instan



	}
}
