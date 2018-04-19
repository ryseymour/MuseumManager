using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelStarter : MonoBehaviour {
	public Transform MuseumPrefab;
	public Transform spawnpoint;
	public Renderer rend;
	public bool Museumbool = false;


	// Use this for initialization
	void Awake () {
		Museumbool = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Museumbool == true){
		Instantiate (MuseumPrefab, spawnpoint.position, spawnpoint.rotation);
		rend.enabled = false;
		Museumbool = false;

	}
}
}
