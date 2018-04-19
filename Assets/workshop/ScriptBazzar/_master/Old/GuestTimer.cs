using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestTimer : MonoBehaviour {

	public Transform guest;
	public Transform guestspawnPoint;

	public float TimeBetweenWaves = 5f;
	private float countdown = 2f;

	private int Guestnumber = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown <= 0f) {
			StartCoroutine(SpawnGuest ());
			countdown = TimeBetweenWaves;

		}

		countdown -= Time.deltaTime;
	}

	IEnumerator SpawnGuest (){
		//for (int i = 0; i < Guestnumber; i++) {
			InstantiateGuest ();
		yield return new WaitForSeconds (5.0f);
		//}
		//Guestnumber++;
	}

	void InstantiateGuest ()
	{
		Instantiate (guest, guestspawnPoint.position, guestspawnPoint.rotation);
	}
}
