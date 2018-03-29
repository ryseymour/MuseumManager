using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class AuctionSelectable
{
    public Image selectIcon;
    public Text selectName;
    public Text startBid;
    public Text Theme;
    public Text Condition;
    public Art myArt;

    public void ActivateSelect(Art a)
    {
        selectIcon.sprite = a.view;
        selectName.text = a.name;
        startBid.text = "$" + a.startBid.ToString();
        Theme.text = a.Theme1;
        Condition.text = a.myCondition.ToString();
        myArt = a;
    }
}

public class AuctionBid
{
    public Image bidIcon;
    public Text currentBid;
    public Text raiseText;
    public Text bidDescription;

    public void ActivateBid()
    {

    }
}

public class AuctionScreen : MonoBehaviour
{
    public List<AuctionSelectable> selectables = new List<AuctionSelectable>();
    public AuctionBid bidable;

    public GameObject AuctionPanel; //main auction panel
    public bool selectMode, bidMode;

    public List<Art> testArt = new List<Art>();

    public float posStep; //it's 3
    public float posID; //the page number for selection page

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < testArt.Count; i++)
        {
            testArt[i].displayed = false;
            testArt[i].researched = false;
        }
        posID = 0;
        AuctionStart();
    }

    public void AuctionStart()
    {
        AuctionPanel.SetActive(true);
        PopulateSelect();
        //populate selection

    }

    void PopulateSelect()
    {
        for (int i = 0; i < selectables.Count; i++)
        {
            if (!testArt[i + Mathf.FloorToInt(posID * posStep)].researched)
            {
                selectables[i].ActivateSelect(testArt[i + Mathf.FloorToInt(posID * posStep)]);
                //testArt[i].displayed = true;
            }
           
        }
    }

    public void NextPage()
    {
        Debug.Log(testArt.Count);
        Debug.Log((1+posID)*posStep);
        if (testArt.Count > Mathf.FloorToInt(1+posID * posStep))
        {
            posID++;
        }
        
        PopulateSelect();
    }

    public void BackPage()
    {
        if (posID > 0)
        {
            posID--;
        }

        PopulateSelect();
    }
}
