using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Master_Art : MonoBehaviour {

	public static Master_Art instance = null;
	public static bool TimerActive = false;
	public static bool ResearchComplete = false;
	public GameObject ResearchBranches;
	public Art art1;
	public Art art2;
	public Art art3;
	public Art artResearch;
	public Art rart;

	public static int RestoreThumbnail;

	public static int dirtyspots;
	public static int placeclick;

	public static Transform ArtPlacement;

	public GameObject Unlock2;

	public GameObject Research1;
	public GameObject Research2;
	public GameObject Research3;

	//public GameObject Restore1;

	public static int ARValue;

	public GameObject RestoreButton;
	public GameObject CollectionPaintingButton;
   
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

	public int n = 0;

	public int CommunityHealth = 50;
	//public Text HealthText;
	public bool timerText = false;

	public Transform spawnpoint;
	public Canvas spawnpointimage;

    bool repop; //only run once repopulate after thetimer
    GameObject temp; //helps read what button is being pressed
	GameObject tempAR;
	GameObject tempCoL;
	public GameObject im2;
	Sprite Restore2;
	Canvas RestoreSpots;

    public List<GameObject> restoreThumbnails = new List<GameObject>();
	public List<GameObject> collectionThumbnails = new List<GameObject>();
	public List<GameObject> collectionLocations = new List<GameObject> ();
	public List<GameObject> researchThumbnails = new List<GameObject> ();
	public List<int> numbers = new List<int> ();

    public int lastrando;

	public Renderer rend;


	GameObject temporaryRestore; //so we can isntantiate and then destroy an object that is being restored
	public Sprite imageRestore;
	public Canvas canvasRestore;
	public GameObject imageComplete;

	GameObject Restore;
	public static bool resetcolbool;

	public static bool TurnOnCol;


	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy(gameObject);
	}

    private void Start()
    {
		TurnOnCol = false;
		for (int i = 0; i < MasterArtList.Count; i++) {
			MasterArtList [i].researched = false;
			MasterArtList [i].restored = false;
			MasterArtList [i].displayed = false;
		}
		//dirtyspots = 7;
		//rend = GetComponent<Renderer> ();
		rend.enabled = false;
        for(int i=0; i < restoreThumbnails.Count; i++)
        {
            restoreThumbnails[i].gameObject.SetActive(false);
        }

		for (int i = 0; i < collectionThumbnails.Count; i++) {
			collectionThumbnails[i].gameObject.SetActive(false);
		}

		for (int i = 0; i < collectionLocations.Count; i++) {
			collectionLocations[i].gameObject.SetActive(true);
		}

		for (int i = 0; i < researchThumbnails.Count; i++) {
			researchThumbnails[i].gameObject.SetActive(false);
		}
		resetcolbool = false;
    }

	public void ResearchPopulate()
	{
		int counter = 0;

		Debug.Log("restore test");
		for (int i = 0; i < researchThumbnails.Count; i++) {
			researchThumbnails [i].transform.GetChild (2).GetComponent<Text> ().text = "";
			researchThumbnails [i].transform.GetChild (3).GetComponent<Text> ().text = "";
			researchThumbnails[i].transform.GetChild(4).GetComponent<Text>().text = "";
			researchThumbnails[i].transform.GetChild(5).GetComponent<Text>().text = "";
			researchThumbnails[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
			//Debug.Log (art1.name);
			//Debug.Log(art1.view.name); 

			researchThumbnails[i].GetComponent<ResearchButtonscript> ().myArt = null;


			if (!Master_Art.instance.MasterArtList[i].researched) {

				//int i = Random.Range(0, Master_Art.instance.MasterArtList.Count);
				//artResearch = Master_Art.instance.MasterArtList [i];
				artResearch = MasterArtList [i];


				researchThumbnails[i].SetActive(true);
				researchThumbnails[i].transform.GetChild(2).GetComponent<Text>().text = artResearch.name;
				researchThumbnails[i].transform.GetChild(3).GetComponent<Text>().text = artResearch.artist;
				researchThumbnails[i].transform.GetChild(4).GetComponent<Text>().text = artResearch.Theme1;
				researchThumbnails[i].transform.GetChild(5).GetComponent<Text>().text = artResearch.Theme2;
				researchThumbnails[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = artResearch.view;
				//Debug.Log (art1.name);
				//Debug.Log(art1.view.name); 

				researchThumbnails[i].GetComponent<ResearchButtonscript> ().myArt = artResearch;



				counter++;


			}
		}
		/*for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			n = 0;
			while (n<1)
			{
				int rando = Random.Range(0, Master_Art.instance.MasterArtList.Count);
				if (!numbers.Contains(rando)) {
					numbers.Add (rando);
					Debug.Log (rando + "rando");
					Debug.Log (numbers + "numbers");
					Debug.Log (numbers.Contains(rando) + "numbers");
					numbers.ForEach (delegate(int randos) {
						Debug.Log (name);
					});

					n++;
				} else {
					n = 0;
				}
				Debug.Log (rando + "rando");
				Debug.Log (lastrando + "lastrando");


				if (!Master_Art.instance.MasterArtList[i].researched) {
					//artResearch = Master_Art.instance.MasterArtList [i];
					artResearch = Master_Art.instance.MasterArtList [i];


					researchThumbnails[rando].SetActive(true);
					researchThumbnails[rando].transform.GetChild(2).GetComponent<Text>().text = artResearch.name;
					researchThumbnails[rando].transform.GetChild(3).GetComponent<Text>().text = artResearch.artist;
					researchThumbnails[rando].transform.GetChild(4).GetComponent<Text>().text = artResearch.Theme1;
					researchThumbnails[rando].transform.GetChild(5).GetComponent<Text>().text = artResearch.Theme2;
					researchThumbnails[rando].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = artResearch.view;
					//Debug.Log (art1.name);
					//Debug.Log(art1.view.name); 

					researchThumbnails[rando].GetComponent<ResearchButtonscript> ().myArt = artResearch;



					counter++;
}

				
			}
		}*/
	}

	public void ResearchDonation (GameObject obj){
		if (obj == null) {
			return;
		} else {
			int artPos = MasterArtList.IndexOf(obj.GetComponent<ResearchButtonscript>().myArt);
			MasterArtList [artPos].researched = true;
			Debug.Log (MasterArtList [artPos].researched);
			numbers.Clear();
			return;
			//ResearchPopulate ();
			//ARValue = artPos;
		}

	}

	public void RestoreReset ()
	{
		imageComplete.SetActive (false);
		for (int i = 0; i < restoreThumbnails.Count; i++) {
			restoreThumbnails [i].transform.GetChild (2).GetComponent<Text> ().text = "";
			restoreThumbnails [i].transform.GetChild (3).GetComponent<Text> ().text = "";
			restoreThumbnails [i].transform.GetChild (4).GetComponent<Text> ().text = "";
			restoreThumbnails [i].transform.GetChild (5).GetComponent<Text> ().text = "";
			restoreThumbnails [i].transform.GetChild (0).transform.GetChild (0).transform.GetChild (0).GetComponent<Image> ().sprite = null;
		}
	}


    public void RestorePopulate ()
	{
       
		int counter = 0;
        Debug.Log("restore test");
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].researched && !Master_Art.instance.MasterArtList [i].restored) {
				art1 = Master_Art.instance.MasterArtList [i];


                restoreThumbnails[counter].SetActive(true);
				restoreThumbnails[counter].transform.GetChild(2).GetComponent<Text>().text = art1.name;
				restoreThumbnails[counter].transform.GetChild(3).GetComponent<Text>().text = art1.artist;
				restoreThumbnails[counter].transform.GetChild(4).GetComponent<Text>().text = art1.Theme1;
				restoreThumbnails[counter].transform.GetChild(5).GetComponent<Text>().text = art1.Theme2;
				restoreThumbnails[counter].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = art1.view;
				//Debug.Log (art1.name);
				//Debug.Log(art1.view.name); 

				restoreThumbnails [counter].GetComponent<Buttonscript> ().myArt = art1;
                
				
				counter++;
                
		

			}

	}

	}


	public void ARBool ()
	{
		int counter = 0;

		Debug.Log("restore test");
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].researched && !Master_Art.instance.MasterArtList [i].restored) {
				art1 = Master_Art.instance.MasterArtList [i];

				//Debug.Log (art1.name);
				//Debug.Log(art1.view.name); 

				//Debug.Log (name);

				ARInstantiate ();

			}

		}

	}

	public void AR ()
	{
		int counter = 0;

		Debug.Log("restore test");
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].AR) {
				art1 = Master_Art.instance.MasterArtList [i];

				Debug.Log (art1.name);
				Debug.Log(art1.view.name); 
				art1 = Master_Art.instance.MasterArtList [i];
				Instantiate (Master_Art.instance.MasterArtList [i].ARmodel, spawnpoint.position, spawnpoint.rotation);
				rend.enabled = false;

				Debug.Log (name);

			}

		}

	}

	public void ARInstantiate ()
	{		
		if (MasterArtList[ARValue].AR)
		{
			MasterArtList[ARValue].restored = true;
			//temporaryRestore.gameObject.SetActive(false);
			MasterArtList[ARValue].AR = false;
			imageComplete.SetActive (true);

			//UI_Manager Backf = this.GetComponent<UI_Manager> ();
			//Backf.Back ();
		}
	}

	public void RestoreInstantiate(GameObject obj)
	{
		Debug.Log(obj);

		int artPos = MasterArtList.IndexOf(obj.GetComponent<Buttonscript>().myArt);
		Debug.Log(artPos);

		MasterArtList[artPos].AR = true;


		temporaryRestore = (GameObject)Instantiate(MasterArtList[artPos].ARmodel, spawnpoint.position, spawnpoint.rotation);
		//imageRestore = GetComponent<
		//imageRestore = GetComponent<Image>.SourceImage();
		//imageRestore = (Sprite)Instantiate(MasterArtList[artPos].view);
			//(Sprite)Instantiate(MasterArtList[artPos].view, spawnpointimage.position, spawnpointimage.rotation);
		imageRestore = MasterArtList[artPos].view;
		Restore2 = im2.GetComponent<Image> ().sprite = imageRestore;

		canvasRestore = MasterArtList [artPos].dirtyspots;
		RestoreSpots = im2.GetComponent<Canvas> (); 
		RestoreSpots = canvasRestore;
		Debug.Log ("canvas" + canvasRestore);
		Debug.Log ("canvas" + im2.GetComponent<Canvas> ());
		Debug.Log ("image" + imageRestore);
		ARValue = artPos;

		UI_Manager UI = this.GetComponent<UI_Manager>();
		UI.RestoreClean(1);

		if (MasterArtList[artPos].painting)
		{
			Debug.Log ("artpos");

			if(MasterArtList [artPos].myCondition == Condition.poor) {
				UI_Manager UI2 = this.GetComponent<UI_Manager>();
				UI2.RestoreClean(3);
			}

			if(MasterArtList [artPos].myCondition == Condition.clean) {
			UI_Manager UI2 = this.GetComponent<UI_Manager>();
			UI2.RestoreClean(2);
			}

			if(MasterArtList [artPos].myCondition == Condition.pristine) {
				UI_Manager UI2 = this.GetComponent<UI_Manager>();
				UI2.RestoreClean(1);
			}

		}

	}




	public void ARfloat (int f)
	{
        MasterArtList[f].AR = true;
        temporaryRestore = (GameObject)Instantiate(MasterArtList[f].ARmodel, spawnpoint.position, spawnpoint.rotation);
        ARValue = f;

        if (MasterArtList[f].painting == true)
        {
            UI_Manager UI = this.GetComponent<UI_Manager>();
            UI.RestoreClean(1);
        }


        /* NO! We are generic not basic
        if (f == 0)
		{
			MasterArtList[0].AR = true;
			Debug.Log (f + "value");
			Debug.Log ("switch");
			Instantiate (MasterArtList [0].ARmodel, spawnpoint.position, spawnpoint.rotation);
			ARValue = f;



			if (MasterArtList [0].painting == true) {
				UI_Manager UI = this.GetComponent<UI_Manager> ();
				UI.RestoreClean (1);
			}

		}
		if (f == 1) {
			MasterArtList [1].AR = true;
			Debug.Log (f);
			Debug.Log ("switch");
			Instantiate (MasterArtList [1].ARmodel, spawnpoint.position, spawnpoint.rotation);
			rend.enabled = false;

			ARValue = f;

			if (MasterArtList [1].painting == true) {
				UI_Manager UI = this.GetComponent<UI_Manager> ();
				UI.RestoreClean (1);
		}

		if (f == 2) {
			MasterArtList [2].AR = true;
			Debug.Log (f);
			Debug.Log ("switch");
			Instantiate (MasterArtList [2].ARmodel, spawnpoint.position, spawnpoint.rotation);
			rend.enabled = false;
		}
        }     
        */


	
	}

	public void Collectionfloat (int f)
	{

		ARValue = f;
		Debug.Log ("testCollection");
		//Debug.Log (f);
		if (MasterArtList[f].painting == true)
		{
			UI_Manager Place = this.GetComponent<UI_Manager>();
			Place.PlaceConfirm();
		}



	}

	public void CollectionMyArt (GameObject obj)
	{
		Debug.Log ("test");

		int artPos2 = MasterArtList.IndexOf(obj.GetComponent<CollectionButtonscript>().myArt2);
		ARValue = artPos2;
		tempCoL = (GameObject)(MasterArtList [artPos2].ARmodel);
		Debug.Log (tempCoL);
		TurnOnCol = true;

		//return;

	}

	public void CollectionPlace (int f, Vector3 r)
	{
		//Debug.Log ("Collection");
		//Debug.Log (f);
		//Debug.Log (ARValue);
		//int artPos = MasterArtList.IndexOf(obj.GetComponent<CollectionButtonscript>().myArt);
		Debug.Log ("passed");
		temporaryRestore = (GameObject)Instantiate(tempCoL, collectionLocations[f].transform.position, collectionLocations[f].transform.rotation);
		Debug.Log (tempCoL);

		temporaryRestore.transform.eulerAngles = r;

		MasterArtList [ARValue].displayed = true;
		//temporaryRestore = null;
		//MasterArtList [ARValue] = null;
		Debug.Log (temporaryRestore);
		resetcolbool = true;
		Debug.Log (resetcolbool);
		TurnOnCol = false;
		Debug.Log (TurnOnCol);
		ResetCollection ();


			}





	public void CollectionInstantiateTest(GameObject obj)
	{
		Debug.Log(obj);

		int artPos = MasterArtList.IndexOf(obj.GetComponent<CollectionButtonscript>().myArt2);
		Debug.Log(artPos);

		//MasterArtList[artPos].AR = true;


		temporaryRestore = (GameObject)Instantiate(MasterArtList[artPos].ARmodel, spawnpoint.position, spawnpoint.rotation);
		ARValue = artPos;
	}

	public void ResetCollection()
	{
		
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++){
			
		//collectionThumbnails[i].SetActive(true);
			collectionThumbnails [i].transform.GetChild (2).GetComponent<Text> ().text = "";
			collectionThumbnails[i].transform.GetChild(3).GetComponent<Text>().text = "";
			collectionThumbnails[i].transform.GetChild(4).GetComponent<Text>().text = "";
			collectionThumbnails[i].transform.GetChild(5).GetComponent<Text>().text = "";
			collectionThumbnails [i].transform.GetChild (0).transform.GetChild (0).transform.GetChild (0).GetComponent<Image> ().sprite = null;
		//Debug.Log (art1.name);
		//Debug.Log(art1.view.name); 

			collectionThumbnails [i].GetComponent<CollectionButtonscript> ().myArt2 = null;
	}
	}

	public void CollectionPaintingPopulate ()
	{
		resetcolbool = false;
		int counter = 0;
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].researched && Master_Art.instance.MasterArtList [i].restored && !Master_Art.instance.MasterArtList [i].displayed) {
				Debug.Log("collection test");

				art1 = Master_Art.instance.MasterArtList [i];
				collectionThumbnails[counter].SetActive(true);
				collectionThumbnails[counter].transform.GetChild(2).GetComponent<Text>().text = art1.name;
				collectionThumbnails[counter].transform.GetChild(3).GetComponent<Text>().text = art1.artist;
				collectionThumbnails[counter].transform.GetChild(4).GetComponent<Text>().text = art1.Theme1;
				collectionThumbnails[counter].transform.GetChild(5).GetComponent<Text>().text = art1.Theme2;
				collectionThumbnails[counter].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = art1.view;
				Debug.Log (art1.name);
				Debug.Log(art1.view.name); 

				collectionThumbnails [counter].GetComponent<CollectionButtonscript> ().myArt2 = art1;
			

				counter++;
			}
	}
	}

	//public void TestCollection ()

	//{
	//Debug.Log ("Works");
	//}





	//public void Populate()
	//{
	//	for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		//{
		//	if (!Master_Art.instance.MasterArtList[i].researched)
			//{
				//Debug.Log(Master_Art.instance.MasterArtList[i]);
				//int rando = Random.Range(0, Master_Art.instance.MasterArtList.Count);
			//	Debug.Log(rando);

				//if (rando != lastrando) {
					//if (rando == 1) {
						//art1 = Master_Art.instance.MasterArtList [i];
						//title1.text = art1.name;
						//artist1.text = art1.artist;
						//Theme11.text = art1.Theme1;
						//Theme21.text = art1.Theme2;
						//artworkImage1.sprite = art1.view;
						//DisplayCheck ();
					//}
					//if (rando == 2) {
					//	art2 = Master_Art.instance.MasterArtList [i];
						//title2.text = art2.name;
					//	artist2.text = art2.artist;
					//	Theme12.text = art2.Theme1;
						//Theme22.text = art2.Theme2;
						//artworkImage2.sprite = art2.view; 
						//DisplayCheck ();

				//	}
				//	if (rando == 3) {
					//	art3 = Master_Art.instance.MasterArtList [i];
						//title3.text = art3.name;
						//artist3.text = art3.artist;
					//	Theme13.text = art3.Theme1;
						//Theme23.text = art3.Theme2;
						//artworkImage3.sprite = art3.view;  
						//DisplayCheck ();

					//}
                  //  Research1.gameObject.SetActive(true);
                  //  Research2.gameObject.SetActive(true);
                  //  Research3.gameObject.SetActive(true);
                  //  Master_Art.instance.MasterArtList [i].displayed = true;
					//Will need to remove
					//Master_Art.instance.MasterArtList [i].researched = true;
				//	rando = lastrando;
			//	} else {
				//	return;
				//}
             //   

	//}
	//}
	//}
		
	/*

    public void ResearchTest(float f)
    {
        
        if(f == 1)
        {
            temp = Research1.gameObject;
        }
        if(f == 2)
        {
            temp = Research2.gameObject;
        }
        if(f == 3)
        {
            temp = Research3.gameObject;

        }

        StartCoroutine(LoseTime());
        Research1.gameObject.SetActive(false);
        Research2.gameObject.SetActive(false);
        Research3.gameObject.SetActive(false);
    }

	*/
	/*

	public void BoolCheck () {
		
		if (TimerActive == true) {
			ResearchBranches.SetActive (false);
			Debug.Log ("TimerActivetrue");
		} else if (TimerActive == false) {
			Debug.Log ("TimerActivefalse");
			if (ResearchComplete == true) {
				Debug.Log ("ResearchCompletetrue");
			} else if (ResearchComplete == false) {
				//FIRST
				Research1.gameObject.SetActive (true);
				Research2.gameObject.SetActive (true);
				Research3.gameObject.SetActive (true);
				Unlock2.gameObject.SetActive (false);
			//	Populate ();
				//Debug.Log ("ResearchCompletefalse");
			
			}
				
		}
	}


	*/





	void Update ()
    {		
		if (dirtyspots == 0) {
			ARInstantiate ();
		}

		if (placeclick >= 1) {

		}
		/*
		if (timerText = true) {
			if (timeLeft <= 0) {
                if (!repop)
                {
                   // Populate();
                    //enable the researched bool 
                    int tempInt = MasterArtList.IndexOf(temp.GetComponent<ResearchDisplay>().art);
                    MasterArtList[tempInt].researched = true;
                    repop = true;                    
                }
                    
				StopCoroutine ("LoseTime");
				countdownText.text = "Unlock Research";
				finishPlot = true;
				timerText = false;
				Unlock2.gameObject.SetActive (true);
               
			
			} else if (timeLeft >= 0) {
				//FOURTH
				countdownText.text = ("Time Left = " + timeLeft);
				//Unlock2.gameObject.SetActive (false);
			}
		}







	}



	IEnumerator LoseTime()
	{
		while(true)
		{
			yield return new WaitForSeconds (1);
			timeLeft--;
		}

	}



	//public void StartCountdown () {

		//timeLeft -= Time.deltaTime;
		//if (timeLeft < 0)
			//timeLeft = 0;
		//countdownText.text = ("Time Left = " + timeLeft);
	//}
	*/
}
}



