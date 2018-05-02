using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {



	public static UI_Manager instance = null;
	[Range(0.1f, 1f)]
	public float scaleSpeed = 100f;

	public Canvas ArtifactsScreen;
	public Canvas MainScreen;
	public Canvas RestoreScreen;
	public Canvas PaintRestore;
	public Canvas ResearchScreen;
	public Canvas AuctionScreen;
	public Canvas QuestionScreen;
	//public Canvas PaintingCollection;

	public Canvas CorrectScreen;
	public Canvas WrongScreen;

	public Canvas SpotOne;
	public Canvas SpotTwo;
	public Canvas SpotThree;

	public Canvas DirtCanvas;


	public static float donatevalue;
	public static float updateDonateValue;
	public static bool donateNow;

	public float donateMax;
	public Text donateText;

	public int artifactScore;

	public static int artifactint = 0;
	public static int exh = 1;
	public static bool confirmbool = false;

	public static int artifactRestoreint = 0;
	public static bool confirmcleanbool = false;

	public Vector3 targetAngleIEO = new Vector3(0f, 180f, 0f);
	public Vector3 targetAngleO = new Vector3 (0f, 0f, 0f);
	public Vector3 targetAngleNO = new Vector3 (0f, 90f, 0f);
	public Vector3 targetAnglenNO = new Vector3 (0f, -90f, 0f);
	private Vector3 currentAngle;

	public GameObject objectRotate;
	public GameObject cameraObject;
	public GameObject CoreTech;

	public bool Movementbool;
	public Transform Cameraup;
	public Transform EObj;
	public bool EObjbool;
	public Transform OneAObj;
	public bool OneAObjbool;
	public Transform OneBObj;
	public bool OneBObjbool;
	public Transform OneCObj;
	public bool OneCObjbool;

	public static bool SwabOn;
	public static bool SwabTwoOn;
	public static bool SwabThreeOn;

	public GameObject DustArrow;
	public GameObject PatchArrow;
	public GameObject VarnishArrow;

	public float rotateSpeed = 3f;
	bool rotateStatus = false;

	bool rotateStatusLeft = false;

	bool up = false;

	private void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		artifactScore = 1;
		artifactRestoreint = 0;
		OneBObjbool = false;
		Movementbool = false;

		AuctionScreen.gameObject.SetActive(false);

		donateMax = 2000f;
		donateText.text = "$" + donateMax;

	}


	public void Artifacts()
	{
		ArtifactsScreen.gameObject.SetActive(true);
		MainScreen.gameObject.SetActive(false);
		Master_Art.instance.ResetCollection ();
	}

	public void Restore()
	{

		RestoreScreen.gameObject.SetActive(true);
		MainScreen.gameObject.SetActive(false);
		Master_Art.instance.RestoreReset ();
	}

	public void PaintRestoreScreen()
	{
		PaintRestore.gameObject.SetActive(true);
	}

	public void Back()
	{
		ArtifactsScreen.gameObject.SetActive(false);
		RestoreScreen.gameObject.SetActive(false);
		MainScreen.gameObject.SetActive(true);
		PaintRestore.gameObject.SetActive(false);
		ResearchScreen.gameObject.SetActive (false);
		SpotOne.gameObject.SetActive (false);
		SpotTwo.gameObject.SetActive (false);
		SpotThree.gameObject.SetActive (false);
		//PaintingCollection.gameObject.SetActive (false);
	}


	public void StartAuctionScreen()
	{
		AuctionScreen.gameObject.SetActive(true);
	}



	// Research Screen




	public void Research(){
		ResearchScreen.gameObject.SetActive (true);
		MainScreen.gameObject.SetActive (false);
		//this.GetComponent<Master_Art> ().BoolCheck ();
	}

	public void ArtifactPlace(int i)
	{
		Debug.Log(i);
	}
	//Artifact Place
	public void Artifact1 () {
		artifactint = 1;
	}

	public void Artifact2 () {
		artifactint = 2;
	}

	public void Artifact3 () {
		artifactint = 3;
	}

	public void Exhibithall1 () {
		exh = 1;
	}

	public void PlaceConfirm () {
		confirmbool = true;
		ArtifactsScreen.gameObject.SetActive(false);
		Debug.Log ("PlaceConfirm");
		//GameObject.Find("Manager").GetComponent<Button>().artifactScore += 1;
	}

	//Restore Screen
	public void ArtifactRestore1 () {
		artifactRestoreint = 1;
	}

	public void ArtifactRestore2 () {
		artifactRestoreint = 2;
	}

	public void ArtifactRestore3 () {
		artifactRestoreint = 3;
	}

	public void RestoreClean (float f){
		Debug.Log ("test");
		ArtifactsScreen.gameObject.SetActive(false);
		RestoreScreen.gameObject.SetActive(false);
		MainScreen.gameObject.SetActive(false);
		PaintRestore.gameObject.SetActive(true);
		ResearchScreen.gameObject.SetActive (false);

		//dirtspots rePopdirt = DirtCanvas.GetComponentInChildren<dirtspots> ();
		//rePopdirt.RestoreRepeat();


		if (f == 1) {
			SpotOne.gameObject.SetActive (true);
			RestoreReset RestRes =	SpotOne.GetComponent<RestoreReset> ();
			RestRes.RestoreRepeat();
			SpotTwo.gameObject.SetActive (false);
			SpotThree.gameObject.SetActive (false);
			Debug.Log ("spot1");
		}
		if (f == 2) {
			SpotTwo.gameObject.SetActive (true);
			RestoreReset RestRes =	SpotTwo.GetComponent<RestoreReset> ();
			RestRes.RestoreRepeat();
			SpotOne.gameObject.SetActive (false);
			SpotThree.gameObject.SetActive (false);
			Debug.Log ("spot2");
		}
		if (f == 3) {
			SpotThree.gameObject.SetActive (true);
			RestoreReset RestRes =	SpotThree.GetComponent<RestoreReset> ();
			RestRes.RestoreRepeat();
			SpotOne.gameObject.SetActive (false);
			SpotTwo.gameObject.SetActive (false);
			Debug.Log ("spot3");
		}
	}

	public void CleaningTools (float f){
		if (f == 1) {
			Debug.Log ("swab");
			SwabOn = true;
			DustArrow.SetActive (true);
			PatchArrow.SetActive (false);
			VarnishArrow.SetActive (false);
			Debug.Log (SwabOn);
			SwabTwoOn = false;
			SwabThreeOn = false;
			//dirtyspots = 7;
			//Debug.Log (dirtyspots);
		}
		if (f == 2) {
			SwabTwoOn = true;
			SwabOn = false;
			SwabThreeOn = false;
			VarnishArrow.SetActive (true);
			DustArrow.SetActive (false);
			PatchArrow.SetActive (false);
		}

		if (f == 3) {
			SwabThreeOn = true;
			SwabTwoOn = false;
			SwabOn = false;
			PatchArrow.SetActive (true);
			DustArrow.SetActive (false);
			VarnishArrow.SetActive (false);

		}
	}

	public void FinishedRestore () {
		Master_Art RstCmp = this.GetComponent<Master_Art> ();
		RstCmp.ARfloat (Master_Art.ARValue);
	}


	public void PlaceRestoreConfirm () {
		confirmcleanbool = true;
		//GameObject.Find("Manager").GetComponent<Button>().artifactScore += 1;
	}
	//problem
	public void QuestionCanvas () {
		if (textmanager.QuestionCanvasIntiate == true) {
			Debug.Log (textmanager.QuestionCanvasIntiate);
			QuestionScreen.gameObject.SetActive (true);
			Debug.Log ("canvas test");
		}

		if (textmanager.QuestionCanvasIntiate == false) {
			Debug.Log (textmanager.QuestionCanvasIntiate);
			QuestionScreen.gameObject.SetActive (false);
		}
	}

	public void Answer (int i) {
		if (i == 0) {
			CorrectScreen.gameObject.SetActive (false);
			WrongScreen.gameObject.SetActive (false);
		}

		if (i == 1) {
			CorrectScreen.gameObject.SetActive (true);
			QuestionScreen.gameObject.SetActive (false);
		}

		if (i == 2) {
			WrongScreen.gameObject.SetActive (true);
			QuestionScreen.gameObject.SetActive (false);
		}

	}

	public void Subtract(float amount)
	{
		bool limit = true;
		if (limit)
		{
			donateMax -= amount;
			donateText.text = "$" + donateMax;
			limit = false;
		}

	}

	public void Add(float amount)
	{

		donateMax += amount;
		donateText.text = "$" + donateMax;


	}


	// Update is called once per frame
	void Update () {


		if (rotateStatus == true) {
			objectRotate.transform.Rotate (Vector3.back, rotateSpeed * Time.deltaTime);
		}

		if (rotateStatusLeft == true) {
			objectRotate.transform.Rotate (Vector3.forward, rotateSpeed * Time.deltaTime);
		}

		if (up == true){

			//cameraObject.transform.Position(Vector3.up, rotateSpeed * Time.deltaTime);

			cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, Cameraup.position, scaleSpeed * Time.deltaTime);
		}

		if (Movementbool == true) {
			if (EObjbool == true) {
				cameraObject.transform.position = Vector3.Lerp (cameraObject.transform.position, EObj.position, scaleSpeed * Time.deltaTime);
				cameraObject.transform.localRotation = Quaternion.Lerp (cameraObject.transform.rotation, EObj.rotation, scaleSpeed * Time.deltaTime);
			}
			if (OneBObjbool == true) {
				cameraObject.transform.position = Vector3.Lerp (cameraObject.transform.position, OneBObj.position, scaleSpeed * Time.deltaTime);
				cameraObject.transform.localRotation = Quaternion.Lerp (cameraObject.transform.rotation, OneBObj.rotation, scaleSpeed * Time.deltaTime);
				//CoreTech.transform.position = Vector3.Lerp (cameraObject.transform.position, OneBObj.position, scaleSpeed * Time.deltaTime);
				//CoreTech.transform.localRotation = Quaternion.Lerp (cameraObject.transform.rotation, OneBObj.rotation, scaleSpeed * Time.deltaTime);
				//cameraObject.GetComponent<RotateCamera> ().enabled = false;
			}
			if (OneAObjbool == true) {
				cameraObject.transform.position = Vector3.Lerp (cameraObject.transform.position, OneAObj.position, scaleSpeed * Time.deltaTime);
				cameraObject.transform.localRotation = Quaternion.Lerp (cameraObject.transform.rotation, OneAObj.rotation, scaleSpeed * Time.deltaTime);
			}
			if (OneCObjbool == true) {
				cameraObject.transform.position = Vector3.Lerp (cameraObject.transform.position, OneCObj.position, scaleSpeed * Time.deltaTime);
				cameraObject.transform.localRotation = Quaternion.Lerp (cameraObject.transform.rotation, OneCObj.rotation, scaleSpeed * Time.deltaTime);
			}

		} else {
		}


	}
}