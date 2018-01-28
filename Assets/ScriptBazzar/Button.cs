using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;
	public GameObject camera1fps;
	public GameObject camera2fps;
	public bool cswitch = true;
	public Canvas ArtifactsScreen;
	public Canvas MainScreen;
	public Canvas RestoreScreen;
	public Canvas Exhibit1a;
	public Canvas PaintRestore;

	public static float donatevalue;
	public static float updateDonateValue;
	public static bool donateNow;
	public Text donateText;

    public int artifactScore;


	// Use this for initialization
	void Start () {

        artifactScore = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

		donateText.text = "Donations x" + artifactScore.ToString() + " : " + updateDonateValue.ToString ();

		//if (cswitch == true) {
			//camera1.gameObject.SetActive (false);
			//camera2.gameObject.SetActive (true);
		//}
		//if (cswitch == false) {
			//camera1.gameObject.SetActive (true);
			//camera2.gameObject.SetActive (false);
		//}
	}

	public void button () {
		//if (cswitch == true) {
			//cswitch = false;
			//Debug.Log ("switch1");
		//}
		//if (cswitch == false) {
			//cswitch = true;
			//Debug.Log ("switch2");
		//}
		//if (cswitch == true) {
			//camera1fps.gameObject.SetActive (false);
			//camera2fps.gameObject.SetActive (true);
			//camera1.gameObject.SetActive (false);
			//camera2.gameObject.SetActive (true);
			//Debug.Log ("Switch");
			//cswitch = false;
			//return;
	//}
		//if (cswitch == false) {
			//camera1.gameObject.SetActive (true);
			//camera2.gameObject.SetActive (false);
			//camera1fps.gameObject.SetActive (true);
			//camera2fps.gameObject.SetActive (false);
			//Debug.Log ("Switch");
			//cswitch = true;
			//return;
		Exhibit1a.gameObject.SetActive (true);
		MainScreen.gameObject.SetActive (false);

	//}


}

	public void Artifacts () {
		ArtifactsScreen.gameObject.SetActive (true);
		MainScreen.gameObject.SetActive (false);
	}

	public void Restore () {
		RestoreScreen.gameObject.SetActive (true);
		MainScreen.gameObject.SetActive (false);
	}

	public void PaintRestoreScreen () {
		PaintRestore.gameObject.SetActive (true);
	}

	public void Back () {
		ArtifactsScreen.gameObject.SetActive (false);
		Exhibit1a.gameObject.SetActive (false);
		RestoreScreen.gameObject.SetActive (false);
		MainScreen.gameObject.SetActive (true);
		PaintRestore.gameObject.SetActive (false);
	}
}
