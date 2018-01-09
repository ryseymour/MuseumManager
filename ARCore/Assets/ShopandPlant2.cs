using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopandPlant2 : MonoBehaviour {
	public Button Plot1Tomato;
	public Text Pl= null;
	public Button Plot1Lettuce;
	public Button Plot2Tomato;
	public Text Pl2 = null;
	public Button Plot2Lettuce;
	public Button Back;
	public bool ButtonHit = true;
	public GameObject BackMenu;
	public int PL1 = 0;
	public int PL2 = 0;
	public static int PL1days;
	public static int PL2days;
	private bool donate = false;
	private bool donate2 = false;
	public int Communityhealth = 50;
	public Text HealthText;
	public int Money;
	public static int Reset = 0;
	public GameObject garden;
	public int timeLeft = 5;
	public Text countdownText;

	// Use this for initialization
	void Start () {
		
	}

	public void Plot1T()
	{
		if (donate == false) {
			StartCoroutine ("LoseTime");
			PL1 = 1;
			PL1days = 3;
			//Plot1Tomato.interactable = false;
			//Plot1Lettuce.interactable = false;
			ChangetextPl1 ();
		}

		if (donate == true) {
			Communityhealth = Communityhealth + 5;
			GameObject.Find("PlantTomatoes").GetComponentInChildren<Text>().text = "Plant Tomatoes";
			//Plot1Lettuce.interactable = true;
			donate = false;
			return;
		}
	}

	public void Plot1L()
	{
		if (donate == false) {
			PL1 = 2;
			PL1days = 2;
			//Plot1Tomato.interactable = false;
			//Plot1Lettuce.interactable = false;
			ChangetextPl1 ();
		}

		if (donate == true) {
			Communityhealth = Communityhealth + 5;
			GameObject.Find("PlantLettuce").GetComponentInChildren<Text>().text = "Plant Lettuce";
			//Plot1Tomato.interactable = true;
			//Communityhealth = Communityhealth + 5;
			donate = false;
			return;

		}
	}

	public void Plot1O()
	{

	}

	public void Plot2T()
	{
		if (donate2 == false) {
			PL2 = 1;
			PL2days = 3;
			//Plot2Tomato.interactable = false;
			//Plot2Lettuce.interactable = false;
			ChangetextPL2 ();
		}

		if (donate2 == true) {
			Communityhealth = Communityhealth + 5;
			GameObject.Find("PlantTomatoes2").GetComponentInChildren<Text>().text = "Plant Tomatoes";
			//Plot2Lettuce.interactable = true;
			donate2 = false;
			return;
		}
	}

	public void Plot2L()
	{
		if (donate2 == false) {
			PL2 = 2;
			PL2days = 2;
			//Plot2Tomato.interactable = false;
			//Plot2Lettuce.interactable = false;
			ChangetextPL2 ();
		}

		if (donate2 == true) {
			Communityhealth = Communityhealth + 5;
			GameObject.Find("PlantLettuce2").GetComponentInChildren<Text>().text = "Plant Lettuce";
			//Plot2Tomato.interactable = true;
			//Communityhealth = Communityhealth + 5;
			donate2 = false;
			return;

		}
	}

	public void Backb ()
	{
		BackMenu.gameObject.SetActive (false);
		Debug.Log ("hit");
	}

	IEnumerator LoseTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			timeLeft--;
		}
	}

	public void ChangetextPl1 (){
		if (PL1 == 1 && PL1days == 3) {
			//countdownText.text = ("Time Left = " + timeLeft);
			GameObject.Find("PlantTomatoes").GetComponentInChildren<Text>().text = ("Time Left = " + timeLeft);
		}

		if (PL1 == 1 && PL1days == 2) {
			GameObject.Find("PlantTomatoes").GetComponentInChildren<Text>().text = "2 days to harvest";
		}

		if (PL1 == 1 && PL1days == 1) {
			GameObject.Find("PlantTomatoes").GetComponentInChildren<Text>().text = "1 days to harvest";
		}

		if (PL1 == 1 && PL1days == 0) {
			GameObject.Find("PlantTomatoes").GetComponentInChildren<Text>().text = "Donate to Food Bank";
			//Plot1Tomato.interactable = true;
			donate = true;
		}

		if (PL1 == 2 && PL1days == 2) {
			GameObject.Find("PlantLettuce").GetComponentInChildren<Text>().text = "2 days to harvest";
		}

		if (PL1 == 2 && PL1days == 1) {
			GameObject.Find("PlantLettuce").GetComponentInChildren<Text>().text = "1 days to harvest";
		}

		if (PL1 == 2 && PL1days == 0) {
			GameObject.Find("PlantLettuce").GetComponentInChildren<Text>().text = "Donate to Food Bank";
			//Plot1Lettuce.interactable = true;
			donate = true;
		}

		return;
	}

	public void ChangetextPL2 (){
		if (PL2 == 1 && PL2days == 3) {
			GameObject.Find("PlantTomatoes2").GetComponentInChildren<Text>().text = "3 days to harvest";
		}

		if (PL2 == 1 && PL2days == 2) {
			GameObject.Find("PlantTomatoes2").GetComponentInChildren<Text>().text = "2 days to harvest";
		}

		if (PL2 == 1 && PL2days == 1) {
			GameObject.Find("PlantTomatoes2").GetComponentInChildren<Text>().text = "1 days to harvest";
		}

		if (PL2 == 1 && PL2days == 0) {
			GameObject.Find("PlantTomatoes2").GetComponentInChildren<Text>().text = "Donate to Food Bank";
			//Plot2Tomato.interactable = true;
			donate2 = true;
		}

		if (PL2 == 2 && PL2days == 2) {
			GameObject.Find("PlantLettuce2").GetComponentInChildren<Text>().text = "2 days to harvest";
		}

		if (PL2 == 2 && PL2days == 1) {
			GameObject.Find("PlantLettuce2").GetComponentInChildren<Text>().text = "1 days to harvest";
		}

		if (PL2 == 2 && PL2days == 0) {
			GameObject.Find("PlantLettuce2").GetComponentInChildren<Text>().text = "Donate to Food Bank";
			//Plot2Lettuce.interactable = true;
			donate2 = true;
		}

		return;
	}

	public void EndofDay () {
		PL1days = PL1days - 1;
		PL2days = PL2days - 1;
		Communityhealth = Communityhealth - 2;
		ChangetextPl1 ();
		ChangetextPL2 ();
	}

	public void Startover () {
		//int Reset = GameObject.Find ("ExampleController").GetComponent<HelloARController> ().CurrentnumberofCities;
		//HelloARController.CurrentnumberofCities = HelloARController.CurrentnumberofCities - 1;
		Reset = 1;
		Destroy (garden);

	}
	
	// Update is called once per frame
	void Update () {
		//royalty free music from www.purple-planet.com
		//soundjay.com
		HealthText.text = "Community Health " + Communityhealth.ToString ();
	}
}
