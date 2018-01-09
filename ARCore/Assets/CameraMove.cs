using UnityEngine;
using System.Collections;

public class CameraMove: MonoBehaviour {
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	public float startTime;
	public float journeyLength;
	public float fracJourney;
	//public float negfracJourney;

	public static bool lerpc1 = false;
	public bool lerpc1b = false;
	void Awake() {
		//startTime = Time.time;
		//journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	void Update() {

		if (lerpc1 == true) {
			//Lerpc1cmove1 ();
			//transform.position = Vector3.Lerp(startMarker.position, endMarker.position);
			//transform.position = new Vector3(endMarker, 0, 0);
			//transform.Translate(endMarker);	
		}

		//if (lerpc1b == true) {
		//float distCovered = (Time.time - startTime) * speed;
		//fracJourney = distCovered / journeyLength;
		//negfracJourney = -(distCovered / journeyLength);
		
}
	}

	//void Lerpc1cmove1 (){
		//lerpc1 = false;
		//lerpc1b = true;
		//Debug.Log ("test");

	//}

