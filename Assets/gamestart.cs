using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void StartButton() {
		SceneManager.LoadScene ("test", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
