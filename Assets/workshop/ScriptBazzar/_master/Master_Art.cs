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

	public static int RestoreThumbnail;

	public static int dirtyspots;
	public static int placeclick;

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

	public int CommunityHealth = 50;
	//public Text HealthText;
	public bool timerText = false;

	public Transform spawnpoint;

    bool repop; //only run once repopulate after thetimer
    GameObject temp; //helps read what button is being pressed
	GameObject tempAR;

    public List<GameObject> restoreThumbnails = new List<GameObject>();
	public List<GameObject> collectionThumbnails = new List<GameObject>();
	public List<GameObject> collectionLocations = new List<GameObject> ();

    public int lastrando;

	public Renderer rend;


    GameObject temporaryRestore; //so we can isntantiate and then destroy an object that is being restored


	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy(gameObject);
	}

    private void Start()
    {
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
    }

    public void RestorePopulate ()
	{
        int counter = 0;
       
        Debug.Log("restore test");
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].researched && !Master_Art.instance.MasterArtList [i].restored) {
				art1 = Master_Art.instance.MasterArtList [i];
                //title1.text = art1.name;
				//artist1.text = art1.artist;
				//Theme11.text = art1.Theme1;
				//Theme21.text = art1.Theme2;
				//artworkImage1.sprite = art1.view;

                restoreThumbnails[counter].SetActive(true);
				restoreThumbnails[counter].transform.GetChild(2).GetComponent<Text>().text = art1.name;
				restoreThumbnails[counter].transform.GetChild(3).GetComponent<Text>().text = art1.artist;
				restoreThumbnails[counter].transform.GetChild(4).GetComponent<Text>().text = art1.Theme1;
				restoreThumbnails[counter].transform.GetChild(5).GetComponent<Text>().text = art1.Theme2;
				restoreThumbnails[counter].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = art1.view;
				Debug.Log (art1.name);
				Debug.Log(art1.view.name); 
                
                //artist1.text = art1.artist;
               // Theme11.text = art1.Theme1;
                //Theme21.text = art1.Theme2;
                //artworkImage1.sprite = art1.view;
               // GameObject button = Instantiate (RestoreButton) as GameObject;
				
				counter++;
                

                

				//button.transform.SetParent (RestoreButton.transform.parent, false);


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

				Debug.Log (art1.name);
				Debug.Log(art1.view.name); 

				//int Art = Master_Art.instance.MasterArtList.IndexOf (this);
				//Debug.Log (Art);
				//Master_Art.instance.MasterArtList.IndexOf [this].AR = true;
				//Art test = Master_Art.instance.MasterArtList;
				//Debug.Log (test+ "test");
				//string name =  EventSystem.current.currentSelectedGameObject.name;
				Debug.Log (name);

				ARInstantiate ();



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

		MasterArtList[f].AR = true;
		//temporaryRestore = (GameObject)Instantiate(MasterArtList[f].ARmodel, spawnpoint.position, spawnpoint.rotation);
		ARValue = f;

		if (MasterArtList[f].painting == true)
		{
			UI_Manager Place = this.GetComponent<UI_Manager>();
			Place.PlaceConfirm();
		}
		//int counter = 0;
		//for(int i =0; i < Master_Art.instance.MasterArtList.Count; i++)
		//{
			//if (Master_Art.instance.MasterArtList [i].restored) {
				//art1 = Master_Art.instance.MasterArtList [i];

				//collectionThumbnails[counter].SetActive(true);
				//collectionThumbnails[counter].transform.GetChild(2).GetComponent<Text>().text = art1.name;
				//collectionThumbnails[counter].transform.GetChild(3).GetComponent<Text>().text = art1.artist;
				//collectionThumbnails[counter].transform.GetChild(4).GetComponent<Text>().text = art1.Theme1;
				//collectionThumbnails[counter].transform.GetChild(5).GetComponent<Text>().text = art1.Theme2;
				//collectionThumbnails[counter].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = art1.view;
				//Debug.Log (art1.name);
				//Debug.Log(art1.view.name); 
			//}
//	}
	}

	public void CollectionPlace (int f)
	{
		Debug.Log ("start");
		int counter = 0;

		Debug.Log("restore test");
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].AR) {
				art1 = Master_Art.instance.MasterArtList [i];

				Debug.Log (art1.name);
				Debug.Log (art1.view.name); 
				art1 = Master_Art.instance.MasterArtList [i];
				Instantiate (Master_Art.instance.MasterArtList [i].ARmodel, collectionThumbnails[f].transform.position, collectionThumbnails[f].transform.rotation);
				Debug.Log (name);
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
				//int Art = Master_Art.instance.MasterArtList.IndexOf (this);
				//Debug.Log (Art);
				//Master_Art.instance.MasterArtList.IndexOf [this].AR = true;
				//Art test = Master_Art.instance.MasterArtList;
				//Debug.Log (test+ "test");
				//string name =  EventSystem.current.currentSelectedGameObject.name;
				Debug.Log (name);

				//ARInstantiate ();



			}

		}

	}

	public void ARInstantiate ()
	{		
        if (MasterArtList[ARValue].AR)
        {
            MasterArtList[ARValue].restored = true;
            temporaryRestore.gameObject.SetActive(false);
            MasterArtList[ARValue].AR = false;
        }
    }



	public void CollectionPaintingPopulate ()
	{
		int counter = 0;
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (Master_Art.instance.MasterArtList [i].researched && Master_Art.instance.MasterArtList [i].restored && Master_Art.instance.MasterArtList [i].painting) {
				//GameObject collectionbutton = Instantiate (CollectionPaintingButton) as GameObject;
				Debug.Log("collection test");
				//art1 = Master_Art.instance.MasterArtList [i];
				//title1.text = art1.name;
				//artist1.text = art1.artist;
				//Theme11.text = art1.Theme1;
				//Theme21.text = art1.Theme2;
				//artworkImage1.sprite = art1.view;
               
				//collectionbutton.transform.SetParent (RestoreButton.transform.parent, false);
				art1 = Master_Art.instance.MasterArtList [i];
				collectionThumbnails[counter].SetActive(true);
				collectionThumbnails[counter].transform.GetChild(2).GetComponent<Text>().text = art1.name;
				collectionThumbnails[counter].transform.GetChild(3).GetComponent<Text>().text = art1.artist;
				collectionThumbnails[counter].transform.GetChild(4).GetComponent<Text>().text = art1.Theme1;
				collectionThumbnails[counter].transform.GetChild(5).GetComponent<Text>().text = art1.Theme2;
				collectionThumbnails[counter].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = art1.view;
				Debug.Log (art1.name);
				Debug.Log(art1.view.name); 

				counter++;
			}
	}
	}


	public void Populate()
	{
		for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
		{
			if (!Master_Art.instance.MasterArtList[i].researched)
			{
				//Debug.Log(Master_Art.instance.MasterArtList[i]);
				int rando = Random.Range(0, Master_Art.instance.MasterArtList.Count);
				Debug.Log(rando);

				if (rando != lastrando) {
					if (rando == 1) {
						art1 = Master_Art.instance.MasterArtList [i];
						title1.text = art1.name;
						artist1.text = art1.artist;
						Theme11.text = art1.Theme1;
						Theme21.text = art1.Theme2;
						artworkImage1.sprite = art1.view;
						//DisplayCheck ();
					}
					if (rando == 2) {
						art2 = Master_Art.instance.MasterArtList [i];
						title2.text = art2.name;
						artist2.text = art2.artist;
						Theme12.text = art2.Theme1;
						Theme22.text = art2.Theme2;
						artworkImage2.sprite = art2.view; 
						//DisplayCheck ();

					}
					if (rando == 3) {
						art3 = Master_Art.instance.MasterArtList [i];
						title3.text = art3.name;
						artist3.text = art3.artist;
						Theme13.text = art3.Theme1;
						Theme23.text = art3.Theme2;
						artworkImage3.sprite = art3.view;  
						//DisplayCheck ();

					}
                    Research1.gameObject.SetActive(true);
                    Research2.gameObject.SetActive(true);
                    Research3.gameObject.SetActive(true);
                    Master_Art.instance.MasterArtList [i].displayed = true;
					rando = lastrando;
				} else {
					return;
				}
                

	}
	}
	}

	//public void DisplayCheck (){
		//Art art = this.gameObject.GetComponent<Art> ();
		//art.display = true;
		//return;
	//}


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
				Populate ();
				Debug.Log ("ResearchCompletefalse");
			
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

		if (timerText = true) {
			if (timeLeft <= 0) {
                if (!repop)
                {
                    Populate();
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




		//HealthText.text = "Community Health " + CommunityHealth.ToString ();



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
}



