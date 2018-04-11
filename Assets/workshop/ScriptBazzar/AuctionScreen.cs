using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class AuctionScreen : MonoBehaviour
{
    public static AuctionScreen instance = null;
    public List<auctionClass> auctionItems = new List<auctionClass>();

    public auctionClass currentItem;

    public GameObject AuctionPanel; //main auction panel
    public GameObject BidPanel; //individual object to bid on (parent object)


    public bool selectMode, bidMode;

    public List<Art> testArt = new List<Art>();

    public float posStep; //it's 3
    public float posID; //the page number for selection page


    private void Awake()
    {
        instance = this;
        AuctionStart();
    }

    private void OnEnable()
    {
        AuctionStart();
    }
    // Use this for initialization
    void Start()
    {


        posID = 0;
  
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
                //auctionItems[i].ActivateItem(testArt[i + Mathf.FloorToInt(posID * posStep)]);
                auctionItems[i].ActivateItem(Master_Art.instance.MasterArtList[i + Mathf.FloorToInt(posID * posStep)]);
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
        currentItem.AddBid();
        //currentItem.bidAmount += currentItem.myArt.raiseAmount;
        //currentItem.currentBid.text = "Current Bid $" + currentItem.bidAmount;
        Debug.Log(currentItem.bidAmount);
        Debug.Log(currentItem.myArt.raiseAmount);
    }

    public void CloseAuction()
    {
        this.gameObject.SetActive(false);
    }
 
}
