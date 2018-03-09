using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exhibitplace : MonoBehaviour {

	public Transform artifact1Prefab;
	public static Transform artifact2Prefab;

	public Transform spawnPoint;

	public Renderer rend;

	public Vector3 myRotation;

	public GameObject GM;
	public static int artifactNumber = 0;
	public int Objectloc = 0;


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

		Debug.Log ("help!");

		Master_Art Placement = GM.GetComponent<Master_Art> ();
		Placement.CollectionPlace (Objectloc, myRotation);

		//artifact2Prefab = Master_Art.ArtPlacement;
		Debug.Log (artifact2Prefab);
		//Debug.Log (this(Vector3));
		//this.gameObject = Master_Art.ArtPlacement;
		if (UI_Manager.confirmbool == true) {
		}
					//Instantiate (artifact1Prefab, spawnPoint.position, spawnPoint.rotation);
					//rend.enabled = false;
					//artifactNumber = artifactNumber + 1;
			//Master_Art ArtPlace = guest2.GetComponent<Master_Art> ().
					//gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

					//GuestWaypointMove GuestStay = Guest.GetComponent<GuestWaypointMove> ().guestRepeat = gueststay.GetComponent<GuestWaypointMove> ().guestRepeat + 1;

					//GuestStay = guest2.GetComponent<GuestWaypointMove> ().guestRepeat;

					//GuestStay += 1;
			//{
				//{
					


				//}

				//if (UI_Manager.artifactint == 2) {
					//Instantiate (artifact2Prefab, spawnPoint.position, spawnPoint.rotation);
					//rend.enabled = false;
					//artifactNumber = artifactNumber + 1;
				//}
			//}
			//else{
			//	return;
			//}
		//} else {
			//return;
		//}
//}
//}
		//}
	//}
}
}