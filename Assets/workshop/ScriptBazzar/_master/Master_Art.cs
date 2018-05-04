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


			researchThumbnails[i].GetComponent<ResearchButtonscript> ().myArt = null;

			if (!Master_Art.instance.MasterArtList[i].researched) {
				artResearch = MasterArtList [i];
				researchThumbnails[i].SetActive(true);
				researchThumbnails[i].transform.GetChild(2).GetComponent<Text>().text = artResearch.name;
				researchThumbnails[i].transform.GetChild(3).GetComponent<Text>().text = artResearch.artist;
				researchThumbnails[i].transform.GetChild(4).GetComponent<Text>().text = artResearch.Theme1;
				researchThumbnails[i].transform.GetChild(5).GetComponent<Text>().text = artResearch.Theme2;
				researchThumbnails[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = artResearch.view;

				researchThumbnails[i].GetComponent<ResearchButtonscript> ().myArt = artResearch;
				counter++;                
			}
		}
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

			MasterArtList[ARValue].AR = false;
			imageComplete.SetActive (true);

		}
	}

	public void RestoreInstantiate(GameObject obj)
	{
		int artPos = MasterArtList.IndexOf(obj.GetComponent<Buttonscript>().myArt);	

		MasterArtList[artPos].AR = true;

		temporaryRestore = (GameObject)Instantiate(MasterArtList[artPos].ARmodel, spawnpoint.position, spawnpoint.rotation);

		imageRestore = MasterArtList[artPos].view;
		Restore2 = im2.GetComponent<Image> ().sprite = imageRestore;

		canvasRestore = MasterArtList [artPos].dirtyspots;
		RestoreSpots = im2.GetComponent<Canvas> (); 		RestoreSpots = canvasRestore;

		ARValue = artPos;

		UI_Manager UI = this.GetComponent<UI_Manager>();
		UI.RestoreClean(1);

		if (MasterArtList[artPos].painting)
		{
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
	}

	public void Collectionfloat (int f)
	{
		ARValue = f;		

		if (MasterArtList[f].painting == true)
		{
			UI_Manager Place = this.GetComponent<UI_Manager>();
			Place.PlaceConfirm();
		}



	}

	public void CollectionMyArt (GameObject obj)
	{


		int artPos2 = MasterArtList.IndexOf(obj.GetComponent<CollectionButtonscript>().myArt2);
		ARValue = artPos2;
		tempCoL = (GameObject)(MasterArtList [artPos2].ARmodel);

		TurnOnCol = true;


	}

	public void CollectionPlace (int f, Vector3 r)
	{

		temporaryRestore = (GameObject)Instantiate(tempCoL, collectionLocations[f].transform.position, collectionLocations[f].transform.rotation);

		collectionLocations[f].GetComponent<ArtInstallation>().myArt = art1;

		temporaryRestore.transform.eulerAngles = r;

		MasterArtList [ARValue].displayed = true;


		resetcolbool = true;

		TurnOnCol = false;

		ResetCollection ();


	}





	public void CollectionInstantiateTest(GameObject obj)
	{
		int artPos = MasterArtList.IndexOf(obj.GetComponent<CollectionButtonscript>().myArt2);

		temporaryRestore = (GameObject)Instantiate(MasterArtList[artPos].ARmodel, spawnpoint.position, spawnpoint.rotation);
		ARValue = artPos;
	}

	public void ResetCollection()
	{

		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++){			

			collectionThumbnails [i].transform.GetChild (2).GetComponent<Text> ().text = "";
			collectionThumbnails[i].transform.GetChild(3).GetComponent<Text>().text = "";
			collectionThumbnails[i].transform.GetChild(4).GetComponent<Text>().text = "";
			collectionThumbnails[i].transform.GetChild(5).GetComponent<Text>().text = "";
			collectionThumbnails [i].transform.GetChild (0).transform.GetChild (0).transform.GetChild (0).GetComponent<Image> ().sprite = null;

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
				collectionThumbnails[counter].transform.GetChild(0).transform.GetChild (0).transform.GetChild (0).GetComponent<Image>().sprite = art1.view;
				collectionThumbnails [counter].GetComponent<CollectionButtonscript> ().myArt2 = art1;
				counter++;
			}
		}
	}







	void Update ()
	{		
		if (dirtyspots == 0) {
			ARInstantiate ();
		}

		if (placeclick >= 1) {

		}
        for(int i=0; i<collectionLocations.Count; i++)
        {
            Debug.DrawRay(collectionLocations[i].transform.position, collectionLocations[i].transform.forward * 3, Color.blue);
        }
	}
}
