using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Section
{
    public List<GameObject> installations = new List<GameObject>();

    public Transform entrance;
}

public class GM_guestScript : MonoBehaviour {

    public static GM_guestScript instance = null;

    public List<Section> Wings = new List<Section>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
