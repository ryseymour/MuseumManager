using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Section //this is a wing
{
    public List<GameObject> installations = new List<GameObject>();

    public Transform entrance;

	public static List<Art> arts = new List<Art>();
}

public class GM_guestScript : MonoBehaviour {

    public static GM_guestScript instance = null;

    public List<Section> Wings = new List<Section>();
    public List<GameObject> GuestPool = new List<GameObject>();
	public int maxActive;
	public int currentActive;
    public bool visible;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        for(int i = 0; i < maxActive; i++)

        {
			GuestPool [i].SetActive (true);
			currentActive++;

        }
		
	}

    public void DeActivate(int pos)
    {
        GuestPool[pos].SetActive(false);
		currentActive--;
		StartCoroutine ("Timer");

    }

	IEnumerator Timer (){
		yield return new WaitForSeconds (5);
		GuestPool [Random.Range (0, GuestPool.Count)].SetActive (true);
		currentActive++;
	}

}
