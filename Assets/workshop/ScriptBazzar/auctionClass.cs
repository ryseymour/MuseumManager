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
        bidIcon.sprite = myArt.view;
        currentBid.text = "$" + myArt.startBid.ToString();
        raiseText.text = "$" + myArt.raiseAmount.ToString();
        bidArt = myArt;
        bidAmount = myArt.startBid;
    }

  
}
