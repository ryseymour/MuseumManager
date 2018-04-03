using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textmanager : MonoBehaviour {

	List<string> questions = new List<string>() {"First question", "Second question", "Third question", "Fourth Question", "Fifth Question"};

	List<string> firstchoice = new List<string>() {"first choice1","first choice2","first choice3", "first choice 4", "first choice 5" };
	List<string> secondchoice = new List<string>() {"second choice" ,"second choice2","secondchoice3", "second choice 4", "secondchoice 5"};
	List<string> thirdchoice = new List<string>() {"third choice","third choice2","third choice3", "third choice 4", "third choice 5"};
	List<string> fourthchoice = new List<string>() {"fourth choice", "fourth choice2","fourth choice3", "fourth choice 4", "fourth choice 5"};

	public GameObject OneQuestion;
	public GameObject TwoQuestion;
	public GameObject ThreeQuestion;
	public GameObject FourQuestion;

	public static int randQuestion;

	List<string> correctAnswer = new List<string>() {"4","1","2","4","3"};

	public static string selectedAnswer;

	public static bool choiceSelected;

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh> ().text = questions [0];
		//OneQuestion.GetComponent<TextMesh> ().text = firstchoice [0];
		//TwoQuestion.GetComponent<TextMesh> ().text = secondchoice [0];
		//ThreeQuestion.GetComponent<TextMesh> ().text = thirdchoice [0];
		//FourQuestion.GetComponent<TextMesh> ().text = fourthchoice [0];

		QuestionRand ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
				QuestionRand ();

			} else if (correctAnswer [randQuestion] != selectedAnswer) {
				Debug.Log ("incorrect");
			}
		}
	}


}
