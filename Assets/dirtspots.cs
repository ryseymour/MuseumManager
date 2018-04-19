using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtspots : MonoBehaviour {
	public static bool cleaningbool = false;
	//public GameObject GM;

	// Use this for initialization
	void Awake() {

	}

	public void RestoreRepeat () {
		//
		//gameObject.SetActive (true);
		//Debug.Log ("restore");
		Master_Art.dirtyspots = 7;
	}

	void OnMouseOver () {
		if (UI_Manager.SwabOn == true) {
			Debug.Log ("turned on");
			gameObject.SetActive (false);
			Master_Art.dirtyspots -= 1;
			Debug.Log (Master_Art.dirtyspots);
			cleaningbool = true;
			//Master_Art dirt = GameObject.Find("GM").GetComponent<Master_Art> ();
			//dirt.ARfloat (Master_Art.ARValue);

			//UI_Manager dirt = this.GetComponent<UI_Manager> ();
			//dirt.FinishedRestore ();

		}
	}

	public void Spots () {
		if (UI_Manager.SwabOn == true && UI_Manager.SwabThreeOn == false && UI_Manager.SwabTwoOn == false) {
			Debug.Log ("turned on");
			gameObject.SetActive (false);
			Master_Art.dirtyspots -= 1;
			Debug.Log (Master_Art.dirtyspots);
			cleaningbool = true;
		}

	}

	public void SpotsW () {
		if (UI_Manager.SwabTwoOn == true && UI_Manager.SwabOn == false && UI_Manager.SwabThreeOn == false) {
			gameObject.SetActive (false);
			Master_Art.dirtyspots -= 1;
			cleaningbool = true;
		}

	}

	public void SpotsM () {
		if (UI_Manager.SwabThreeOn == true && UI_Manager.SwabTwoOn == false && UI_Manager.SwabOn == false) {
			gameObject.SetActive (false);
			Master_Art.dirtyspots -= 1;
			cleaningbool = true;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}



