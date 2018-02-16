using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Art : MonoBehaviour {

	public static Master_Art instance = null;
   
	public List<Art> MasterArtList = new List<Art>();

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
