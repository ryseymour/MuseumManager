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
        bidAmount += myArt.raiseAmount;
        StartCoroutine("CounterBid");
        currentBid.text = "Current Bid $" + bidAmount;
    }
    
    IEnumerator CounterBid()
    {
        yield return new WaitForSeconds(1);
        if(bidAmount < maxCounter)
        {
            bidAmount += myArt.raiseAmount;
            currentBid.text = "Current Bid $" + bidAmount;
        }
        else
        {
            int tempInt = AuctionScreen.instance.testArt.IndexOf(myArt);

            AuctionScreen.instance.testArt[tempInt].researched = true;
                //used in the live environment
                //Master_Art.instance.MasterArtList.IndexOf(myArt);
            //Master_Art.instance.MasterArtList[tempInt].researched = true;
            AuctionScreen.instance.CloseBid();
        }

    }
  
}
