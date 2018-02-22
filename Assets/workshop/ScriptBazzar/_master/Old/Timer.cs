using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class Timer: MonoBehaviour

{

	//public Button Plot1Tomato;
	//public Button Plot1Lettuce;


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

	void Start ()
	{
		
	}

	public void Box1T ()
	{
		if (tpress == false) {
			//
			//countdownText.text = ("Plant Tomatoes");
			crop = 1;
			//Plot1Lettuce.interactable = false;
			timer1 = true;
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
				countdownText.text = "Donate";
				finishPlot = true;
				timerText = false;
				//timeLeft = 10;
				//ShopandPlant.finishPlot = true;
			} else if (timeLeft >= 0) {

				countdownText.text = ("Time Left = " + timeLeft);

			}
		}

		if (timerText = false) {
			countdownText.text = ("Plant Tomatoes");
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