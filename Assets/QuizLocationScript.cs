using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLocationScript : MonoBehaviour {
	public GameObject QTObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		Debug.Log ("q1test");
		//this.gameObject.SetActive (false);
		textmanager QT = QTObj.GetComponent<textmanager>();

		QT.QuestionOn();

	}

	public void QuizTest () {
		Debug.Log ("q2test");
		textmanager QT = QTObj.GetComponent<textmanager>();

		QT.QuestionOn();
	}
}
