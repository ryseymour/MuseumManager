using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master_Art : MonoBehaviour {

	public static Master_Art instance = null;
	public static bool TimerActive = false;
	public static bool ResearchComplete = false;
	public GameObject ResearchBranches;
	public Art art1;
	public Art art2;
	public Art art3;

	public GameObject Unlock2;

	public GameObject Research1;
	public GameObject Research2;
	public GameObject Research3;
   
	public List<Art> MasterArtList = new List<Art>();

	public Text title1;
	public Text artist1;
	public Image artworkImage1;
	public Text Theme11;
	public Text Theme21;

	public Text title2;
	public Text artist2;
	public Image artworkImage2;
	public Text Theme12;
	public Text Theme22;

	public Text title3;
	public Text artist3;
	public Image artworkImage3;
	public Text Theme13;
	public Text Theme23;

	public static int timeLeft = 10;
	public Text countdownText;
	public static bool timer1 =false;
	public bool tpress = false;
	public int crop = 0;
	public int plot = 1;
	public bool finishPlot = false;

	public int CommunityHealth = 50;
	//public Text HealthText;
	public bool timerText = false;


	public int lastrando;


	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy(gameObject);
	}



	public void Populate()
	{
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (!Master_Art.instance.MasterArtList[i].researched)
			{
				//Debug.Log(Master_Art.instance.MasterArtList[i]);
				int rando = Random.Range(0, 4);
				Debug.Log(rando);

				if (rando != lastrando) {
					if (rando == 1) {
						art1 = Master_Art.instance.MasterArtList [i];
						title1.text = art1.name;
						artist1.text = art1.artist;
						Theme11.text = art1.Theme1;
						Theme21.text = art1.Theme2;
						artworkImage1.sprite = art1.view;
						DisplayCheck ();


					}
					if (rando == 2) {
						art2 = Master_Art.instance.MasterArtList [i];
						title2.text = art2.name;
						artist2.text = art2.artist;
						Theme12.text = art2.Theme1;
						Theme22.text = art2.Theme2;
						artworkImage2.sprite = art2.view; 
						DisplayCheck ();

					}
					if (rando == 3) {
						art3 = Master_Art.instance.MasterArtList [i];
						title3.text = art3.name;
						artist3.text = art3.artist;
						Theme13.text = art3.Theme1;
						Theme23.text = art3.Theme2;
						artworkImage3.sprite = art3.view;  
						DisplayCheck ();

					}
					rando = lastrando;
				} else {
					Populate ();
				}


	}
	}
	}

	public void DisplayCheck (){
		//Art art = this.gameObject.GetComponent<Art> ();
		//art.display = true;
		return;
	}


	public void BoolCheck () {
		Debug.Log ("test");
		if (TimerActive == true) {
			ResearchBranches.SetActive (false);
		} else if (TimerActive == false) {
			if (ResearchComplete == true) {
				
			} else if (ResearchComplete == false) {
				Research1.gameObject.SetActive (true);
				Research2.gameObject.SetActive (true);
				Research3.gameObject.SetActive (true);
				Populate ();
			}
				
		}
	}

	public void Box1T ()
	{
		if (tpress == false) {
			//
			//countdownText.text = ("Plant Tomatoes");
			//crop = 1;
			//Plot1Lettuce.interactable = false;
			timer1 = true;

			Research1.gameObject.SetActive (false);
			Research2.gameObject.SetActive (false);
			Research3.gameObject.SetActive (false);
		}


		if (tpress == true) {





			CommunityBump ();

		}



	}

	public void CommunityBump (){
		//CommunityHealth = CommunityHealth + 5;
		timeLeft = 10;
		countdownText.text = ("Unlock Research");


		//Plot1Lettuce.interactable = true;
		tpress = false;
		Box1T ();

	}





	void Update ()
	{
		if (timerText = true) {
			if (timeLeft <= 0) {
				StopCoroutine ("LoseTime");
				countdownText.text = "Unlock Research";
				finishPlot = true;
				timerText = false;
				//timeLeft = 10;
				//ShopandPlant.finishPlot = true;
			} else if (timeLeft >= 0) {

				countdownText.text = ("Time Left = " + timeLeft);




			}
		}

		if (timerText = false) {
			countdownText.text = ("Unlock Research");
		}


		if (timer1 == true) {
			timerText = true;
			TimerStart ();


		}

		if (finishPlot == true && crop == 1){
			//Plot1Tomato.interactable = true;
			tpress = true;
			Box1T ();

		}



		//HealthText.text = "Community Health " + CommunityHealth.ToString ();



	}

	public void TimerStart (){


		StartCoroutine ("LoseTime");
		timer1 = false;
	}

	IEnumerator LoseTime()
	{

		while(true)
		{
			yield return new WaitForSeconds (1);
			timeLeft--;
		}

	}
}



