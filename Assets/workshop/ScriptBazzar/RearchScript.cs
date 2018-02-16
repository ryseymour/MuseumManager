using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++){
			if (!Master_Art.instance.MasterArtList [i].researched)
				Debug.Log (Master_Art.instance.MasterArtList [i].name);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
