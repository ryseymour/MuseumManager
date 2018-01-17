using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestWaypointMove : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	public int waypointIndex = 0;

	public int guestRepeat = 1;

	public bool Guestcheck = true;
	public float PersonalDonateScore = 0f;


	// Use this for initialization
	void Awake () {
		target = waypoints.points [0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.02f) {
			GetNextWaypoint ();
		}
			

		//if (waypointIndex == 0 && guestRepeat <= 0) {
		//Destroy (gameObject);
		//}
	}

	void GetNextWaypoint ()
	{

		if (waypointIndex >= waypoints.points.Length - 1) {
			//Destroy (gameObject);
			waypointIndex = 0;

			guestRepeat = guestRepeat -1;
		}

		if (ArtifactPlace.artifactint >= 1  && Guestcheck == true) {
			guestRepeat = guestRepeat + 1;
			//add in a random value later
			PersonalDonateScore = PersonalDonateScore + 1f;
			Guestcheck = false;
		}

		if (guestRepeat <= 0) {
			//waypointIndex = -1;
			waypointIndex = Random.Range(0, waypoints.points.Length-1);
			StartCoroutine (DestroyGuest ());
		}

	
		waypointIndex++;
		target = waypoints.points [waypointIndex];
		//target = Random.Range(0, waypointIndex);
	}

	IEnumerator DestroyGuest (){
		yield return new WaitForSeconds (20.0f);
		//remove this at a later point
		PersonalDonateScore = PersonalDonateScore + 1f;
		Button.updateDonateValue = Button.donatevalue + PersonalDonateScore + (0.1f * GameObject.Find("Manager").GetComponent<Button>().artifactScore);
		Button.donatevalue = Button.updateDonateValue;
		//Button.donateNow = true;
		Destroy (gameObject);

	}
}
