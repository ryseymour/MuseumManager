using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Canvas ArtifactsScreen;
    public Canvas MainScreen;
    public Canvas RestoreScreen;
    public Canvas FP_screen;
    public Canvas PaintRestore;


    public static float donatevalue;
    public static float updateDonateValue;
    public static bool donateNow;
    public Text donateText;

    public int artifactScore;

    // Use this for initialization
    void Start () {
        artifactScore = 1;

	}
	
    public void FP_View()
    {
        FP_screen.gameObject.SetActive(true);
        MainScreen.gameObject.SetActive(false);
    }

    public void Artifacts()
    {
        ArtifactsScreen.gameObject.SetActive(true);
        MainScreen.gameObject.SetActive(false);
    }

    public void Restore()
    {
        RestoreScreen.gameObject.SetActive(true);
        MainScreen.gameObject.SetActive(false);
    }

    public void PaintRestoreScreen()
    {
        PaintRestore.gameObject.SetActive(true);
    }

    public void Back()
    {
        ArtifactsScreen.gameObject.SetActive(false);
        FP_screen.gameObject.SetActive(false);
        RestoreScreen.gameObject.SetActive(false);
        MainScreen.gameObject.SetActive(true);
        PaintRestore.gameObject.SetActive(false);
    }

    public void ArtifactPlace(int i)
    {
        Debug.Log(i);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
