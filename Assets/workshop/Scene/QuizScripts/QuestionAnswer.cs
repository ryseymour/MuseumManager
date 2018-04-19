using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswer : MonoBehaviour {
	public GameObject QuestionManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AnswerClick () {
		textmanager.selectedAnswer = gameObject.name;
		textmanager.choiceSelected = true;
		Debug.Log ("Answertest");
		//QuestionManager.GetComponent<textmanager> ().Answer ();
		textmanager answ = QuestionManager.GetComponent<textmanager>();
		answ.Answer ();

	}

	void OnMouseDown () {
		textmanager.selectedAnswer = gameObject.name;
		textmanager.choiceSelected = true;
		Debug.Log ("Answertest");
		//QuestionManager.GetComponent<textmanager> ().Answer ();
		textmanager answ = QuestionManager.GetComponent<textmanager>();
		answ.Answer ();

	}
}
