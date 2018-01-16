using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guestviewmove : MonoBehaviour {
	public float speed = 10f;

	private Transform target;
	public int wavepointIndex = 0;
	public static bool ModelOn = false;
	public bool MoveCameraUpdate = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (ModelOn == true) {
			StartWaypoints ();
		}

		if (MoveCameraUpdate = true) {

		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.2f) {
			GetNextWaypoint ();
		}
			//if (Vector3.Distance (transform.position, target.position) <= 0.01f) {
				//speed = 0f;
		//}
			//if (ModelOn == false) {
				//return;
			//}
	}
	}

	void GetNextWaypoint ()
	{
		if (wavepointIndex >= waypoints.points.Length - 1) {
			//wavepointIndex = -1;
		}
		wavepointIndex++;
		target = waypoints.points [wavepointIndex];
	}

	void StartWaypoints ()
	{
		target = waypoints.points [0];
		ModelOn = false;
		MoveCameraUpdate = true;
	}
}
