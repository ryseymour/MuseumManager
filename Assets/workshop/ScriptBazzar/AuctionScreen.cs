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
    public GameObject BidBKG; //used to cover the Auction panel, can't set it inactive due to scripts attached to objects

    public bool selectMode, bidMode;

    public List<Art> testArt = new List<Art>();

    public float posStep; //it's 3
    public float posID; //the page number for selection page

    public bool bidEnabled; //this is to make sure player can't spam raise their bid until after the computer counters
    public Text currentFunds;


    public GameObject anim_PlayerBid;
    public GameObject anim_CompBid;
    public GameObject anim_BidResult;

    private void Awake()
    {
        instance = this;        
    }

    private void OnEnable()
    {
        Debug.Log("enabled");
        AuctionStart();
    }
    // Use this for initialization
    void Start()
    {
        posID = 0;  
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopulateSelect();
        }
    }

    public void AuctionStart()
    {
        AuctionPanel.SetActive(true);
        PopulateSelect();
        BidPanel.SetActive(false);
        BidBKG.SetActive(false);
        //populate selection

    }

    void PopulateSelect()
    {
        
        int artSkipper = 0; //used to move through art that has already been researched
        for (int i = 0; i < auctionItems.Count; i++)
        {
            auctionItems[i].ClearItems();
            if (!Master_Art.instance.MasterArtList[i + Mathf.FloorToInt(posID * posStep) + artSkipper].researched)
            {
                auctionItems[i].ActivateItem(Master_Art.instance.MasterArtList[i + Mathf.FloorToInt(posID * posStep) + artSkipper]);
            }else
            {
                artSkipper++;
                auctionItems[i].ActivateItem(Master_Art.instance.MasterArtList[i + Mathf.FloorToInt(posID * posStep) + artSkipper]);
            }
            /* Unit test code        
            if (!testArt[i + Mathf.FloorToInt(posID * posStep)].researched)
            {
               // selectables[i].ActivateSelect(testArt[i + Mathf.FloorToInt(posID * posStep)]);
                auctionItems[i].ActivateItem(testArt[i + Mathf.FloorToInt(posID * posStep)]);
               // auctionItems[i].ActivateItem(Master_Art.instance.MasterArtList[i + Mathf.FloorToInt(posID * posStep)]);
                //testArt[i].displayed = true;
            }
            */
           
        }
    }

    public void NextPage()
    {
        
        
        if (Master_Art.instance.MasterArtList.Count > Mathf.FloorToInt(2 + posID * posStep))
        {
            posID++;
        }else
        {
            Debug.Log("wut");
        }

        /* Unit test code
        if (testArt.Count > Mathf.FloorToInt(2+posID * posStep))
        {           
            posID++;
        }else
        {
            Debug.Log("wut");
        }
        */
        
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
        BidBKG.SetActive(true);
        bidEnabled = true;
        currentItem = obj.transform.parent.transform.parent.GetComponent<auctionClass>();
        obj.transform.parent.transform.parent.GetComponent<auctionClass>().ActivateBid();
        currentFunds.text = "$" + UI_Manager.instance.donateMax;
        
    }

    public void FundsUpdate(float amount)
    {
        currentFunds.text = "$" + UI_Manager.instance.donateMax;
        //run an animation

    }

    public void CloseBid()
    {
        if (currentItem.bidActive)
        {
            UI_Manager.instance.donateMax += (currentItem.currentBidAmount/2);
        }
        UI_Manager.instance.donateMax -= currentItem.bidAmount + currentItem.currentBidAmount ;
        Debug.Log(currentItem.bidAmount + currentItem.currentBidAmount);
        UI_Manager.instance.donateText.text = "$" + UI_Manager.instance.donateMax;
        posID++;
        BidPanel.SetActive(false);
        BidBKG.SetActive(false);
        posID--;
        PopulateSelect();
    }

    public void AddBid()
    {
        if (bidEnabled) {
          
            currentItem.AddBid();

            bidEnabled = false;
        }

    }

    public void CloseAuction()
    {
        if (currentItem.bidActive)
        {                     
            UI_Manager.instance.donateMax += (currentItem.currentBidAmount / 2);
            UI_Manager.instance.donateText.text = "$" + UI_Manager.instance.donateMax;
            currentItem.bidActive = false;
        }
        this.gameObject.SetActive(false);
    }

	public void BackAuction()
	{
		Debug.Log ("testauctionclose");
		this.gameObject.SetActive (false);
	}
 
}
