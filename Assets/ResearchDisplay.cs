using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchDisplay : MonoBehaviour {

	public Art art;

	public Text title;
	public Text artist;

	public Image artworkImage;

	public Text Theme1;
	public Text Theme2;





	// Use this for initialization
	void Start () {
		//Random.Range (0, 
		//title.text = art.name;
		//artist.text = art.artist;
		//Theme1.text = art.Theme1;
		//Theme2.text = art.Theme2;
		//artworkImage.sprite = art.view;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
          //  Populate();
        }
	}

   // void Populate()
  //  {
      //  for(int i = 0; i < Master_Art.instance.MasterArtList.Count; i++)
       // {
           // if (!Master_Art.instance.MasterArtList[i].researched)
           // {
                //Debug.Log(Master_Art.instance.MasterArtList[i]);
               // int rando = Random.Range(0, 100);
              //  Debug.Log(rando);
              //  if (rando > 10) {
              //      art = Master_Art.instance.MasterArtList[i];
                  //  title.text = art.name;
                 //   artist.text = art.artist;
                 //   Theme1.text = art.Theme1;
                 //   Theme2.text = art.Theme2;
                  //  artworkImage.sprite = art.view;  
               // }
           // }
       // }
   // }

	//void 


   
}
