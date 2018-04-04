using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class AuctionScreen : MonoBehaviour
{
    
    public List<auctionClass> auctionItems = new List<auctionClass>();

    public auctionClass currentItem;

    public GameObject AuctionPanel; //main auction panel
    public GameObject BidPanel; //individual object to bid on (parent object)


    public bool selectMode, bidMode;

    public List<Art> testArt = new List<Art>();

    public float posStep; //it's 3
    public float posID; //the page number for selection page

    // Use this for initialization
    void Start()
    {
        for(int j=0; j <auctionItems.Count; j++)
        {
            Debug.Log(auctionItems[j].selectName.text);
        }
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
        BidPanel.SetActive(false);
        //populate selection

    }

    void PopulateSelect()
    {
        for (int i = 0; i < auctionItems.Count; i++)
        {
            if (!testArt[i + Mathf.FloorToInt(posID * posStep)].researched)
            {
               // selectables[i].ActivateSelect(testArt[i + Mathf.FloorToInt(posID * posStep)]);
                auctionItems[i].ActivateItem(testArt[i + Mathf.FloorToInt(posID * posStep)]);
                //testArt[i].displayed = true;
            }
           
        }
    }

    public void NextPage()
    {
        Debug.Log(testArt.Count);
        Debug.Log((2+posID)*posStep);
        if (testArt.Count > Mathf.FloorToInt(2+posID * posStep))
        {           
            posID++;
        }else
        {
            Debug.Log("wut");
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

    public void BidSelect()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        BidPanel.SetActive(true);
        currentItem = obj.transform.parent.GetComponent<auctionClass>();
        obj.transform.parent.GetComponent<auctionClass>().ActivateBid();
        Debug.Log(obj.transform.parent.GetComponent<auctionClass>().myArt);
    }
    public void CloseBid()
    {
        BidPanel.SetActive(false);
    }

    public void AddBid()
    {
        //check if there's enough money
        
        currentItem.bidAmount += currentItem.myArt.raiseAmount;
        currentItem.currentBid.text = "$" + currentItem.bidAmount;
        Debug.Log(currentItem.bidAmount);
        Debug.Log(currentItem.myArt.raiseAmount);
    }

}
