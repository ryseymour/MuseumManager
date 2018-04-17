using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class auctionClass : MonoBehaviour {
    public Image selectIcon;
    public Text selectName;
    public Text startBid;
    public Text Theme;
    public Text Condition;
	public Text Artist;
    public Art myArt;

    public Image bidIcon;
    public Text currentBid;
    public float bidAmount;
    public Text raiseText;
    public Text bidDescription;
    public Art bidArt;
    public float maxCounter;
   

    public void ActivateItem(Art a)
    {
        selectIcon.sprite = a.view;
        selectName.text = a.name;
        startBid.text = "$" + a.startBid.ToString();
        Theme.text = a.Theme1;
		Artist.text = a.artist;
        Condition.text = a.myCondition.ToString();
        myArt = a;
    }

    public void ActivateBid()
    {
        bidAmount = myArt.startBid;
        bidIcon.sprite = myArt.view;
        currentBid.text = "Current Bid $" + bidAmount;
        raiseText.text = "+$" + myArt.raiseAmount.ToString();
        bidArt = myArt;
        maxCounter = bidAmount * 1.75f;
        
        Debug.Log(bidAmount + " : " + myArt.startBid + " max counter: " + maxCounter);
        
    }


    public void AddBid()
    {
        //check if there's enough money

        if(bidAmount+myArt.raiseAmount <= UI_Manager.instance.donateMax)
        {
            UI_Manager.instance.Subtract(myArt.raiseAmount);
            AuctionScreen.instance.FundsUpdate(myArt.raiseAmount);
            bidAmount += myArt.raiseAmount;
            AuctionScreen.instance.anim_PlayerBid.GetComponent<Text>().text = "+" + myArt.raiseAmount;
            AuctionScreen.instance.anim_PlayerBid.GetComponent<Animator>().Play("playerBid");
            StartCoroutine("CounterBid");
            currentBid.text = "Current Bid $" + bidAmount;
        }
        else
        {
            Debug.Log("not enough money");
        }

    }
    
    IEnumerator CounterBid()
    {

        yield return new WaitForSeconds(1.25f);
       
        if(bidAmount < maxCounter)
        {
            AuctionScreen.instance.anim_CompBid.GetComponent<Text>().text = "+" + myArt.raiseAmount;
            AuctionScreen.instance.anim_CompBid.GetComponent<Animator>().Play("compBid");
            yield return new WaitForSeconds(0.75f);
            bidAmount += myArt.raiseAmount;
            currentBid.text = "Current Bid $" + bidAmount;
            
            AuctionScreen.instance.bidEnabled = true;
        }
        else
        {
            AuctionScreen.instance.anim_CompBid.GetComponent<Text>().text = "withdraw";
            AuctionScreen.instance.anim_CompBid.GetComponent<Animator>().Play("compWithdraw");
            yield return new WaitForSeconds(2);
            //int tempInt = AuctionScreen.instance.testArt.IndexOf(myArt);

            // AuctionScreen.instance.testArt[tempInt].researched = true;
            //used in the live environment
            int tempInt = Master_Art.instance.MasterArtList.IndexOf(myArt);
            Master_Art.instance.MasterArtList[tempInt].researched = true;
            AuctionScreen.instance.CloseBid();
            AuctionScreen.instance.BidBKG.SetActive(false);
           
        }

    }
  
}
