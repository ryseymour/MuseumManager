using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textmanager : MonoBehaviour {

	List<string> questions = new List<string>() {"Where did Van Gogh get his inspiration for the Starry Night?", "How many paintings of Sunflowers did Van Gogh make?", "How much is the Mona Lisa worth?", "Madame Lebrun was best known for this type of art.", "Huizong was not only an artist but also"};

	List<string> firstchoice = new List<string>() {"Local Restaurant","Seven","One Million Dollars", "Landscapes", "a Merchant" };
	List<string> secondchoice = new List<string>() {"Traveling" ,"One","Eight Hundred Million Dollars", "Abstract", "a Warrior"};
	List<string> thirdchoice = new List<string>() {"Inn Rooftop","Ten","One Billion Dollars", "Photography", "an Emperor"};
	List<string> fourthchoice = new List<string>() {"Bedroom Window", "Twelve","Six Hundred Million Dollars", "Portraits", "a Traveler"};

	public GameObject OneQuestion;
	public GameObject TwoQuestion;
	public GameObject ThreeQuestion;
	public GameObject FourQuestion;

	public static int randQuestion;
	public static int answer;

	List<string> correctAnswer = new List<string>() {"4","1","2","4","3"};

	public static string selectedAnswer;

	public static bool choiceSelected;
	public static bool QuestionIntiate;
	public static bool QuestionCanvasIntiate;
	public static bool QuestionStart;

	public GameObject GMObj;
	public GameObject QuestionBlock;

	public GameObject Correct;
	public GameObject Wrong;

	// Use this for initialization
	void Start () {
		//QuestionStart = false;
		QuestionIntiate = false;
		QuestionCanvasIntiate = false;
		//GetComponent<TextMesh> ().text = questions [0];
		//OneQuestion.GetComponent<TextMesh> ().text = firstchoice [0];
		//TwoQuestion.GetComponent<TextMesh> ().text = secondchoice [0];
		//ThreeQuestion.GetComponent<TextMesh> ().text = thirdchoice [0];
		//FourQuestion.GetComponent<TextMesh> ().text = fourthchoice [0];

		//QuestionRand ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (GuestScript.triviaSwitch == true) {

				QuestionBlock.SetActive (true);



		}
		if (GuestScript.triviaSwitch == false) {
			QuestionBlock.SetActive (false);
		}
	}
	//for clicking on guest
	public void QuestionOn (){
		//QuestionIntiate = !QuestionIntiate;
		//QuestionIntiate = false;
		Debug.Log (QuestionIntiate);
		if (QuestionIntiate == false) {
			QuestionCanvasIntiate = true;
			Debug.Log (QuestionCanvasIntiate);
			UI_Manager QuestCanv = GMObj.GetComponent<UI_Manager>();
			QuestCanv.QuestionCanvas();
			QuestionRand ();
			Debug.Log ("QTCanvasTest");
			return;
		}

		if (QuestionIntiate == true) {
			QuestionCanvasIntiate = false;
			Debug.Log (QuestionCanvasIntiate);
			UI_Manager QuestCanv = GMObj.GetComponent<UI_Manager>();
			QuestCanv.QuestionCanvas();
			return;
		}

	}

	public void QuestionRand (){
		randQuestion = Random.Range (0, 5);
		QuestionPop ();
	}

	void QuestionPop (){
		GetComponent<Text> ().text = questions [randQuestion];
		OneQuestion.GetComponent<Text> ().text = firstchoice [randQuestion];
		TwoQuestion.GetComponent<Text> ().text = secondchoice [randQuestion];
		ThreeQuestion.GetComponent<Text> ().text = thirdchoice [randQuestion];
		FourQuestion.GetComponent<Text> ().text = fourthchoice [randQuestion];
	}

	public void Answer (){
		if (choiceSelected == true) {

			choiceSelected = false;

			if (correctAnswer [randQuestion] == selectedAnswer) {
				
				Debug.Log ("correct");
				QuestionBlock.SetActive (false);
				QuestionIntiate = true;
				GuestScript.questionCorrect = 50f;
				//Correct.SetActive (true);
				answer = 1;
				UI_Manager CR = GMObj.GetComponent<UI_Manager>();
				CR.Answer(1);
				QuestionOn ();


			} else if (correctAnswer [randQuestion] != selectedAnswer) {
				
				Debug.Log ("incorrect");
				QuestionBlock.SetActive (false);
				QuestionIntiate = true;
				GuestScript.questionCorrect = -25f;
				//Wrong.SetActive (true);
				answer = 2;
				UI_Manager CR = GMObj.GetComponent<UI_Manager>();
				CR.Answer(2);
				QuestionOn ();
			}
		}
	}
		


}
