using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestScript : MonoBehaviour {


    public bool enter, travel, search, view, use, exit;
    /// <summary>
    /// init, moving between wings/facilities, look for next wing/facility, view exhibits, use facility, exit museum
    /// </summary>
    bool view_init;
    int pos_artQ;
    public List<GameObject> artQ = new List<GameObject>(); //whaddaya gonna look at next?

    public Section wingTarget;
    
    

    public float speed, patience, noise, timer, tick;

	// Use this for initialization
	void Start () {
        _Enter();
        view_init = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            view_init = false;
            view = false;
            travel = false;
            enter = true;
            _Enter();
        }

        _Travel();
        _View();
        _Search();
	}

    void _Enter()
    {
        if (enter)
        {
            float rando = Random.Range(0, GM_guestScript.instance.Wings.Count);
            wingTarget = GM_guestScript.instance.Wings[Mathf.FloorToInt(rando)];           
            travel = true;
            enter = false;
        }else
        {
            return;
        }
    }

    void _Travel()
    {
        if (travel)
        {
            transform.position = Vector3.Lerp(this.transform.position, wingTarget.entrance.position, speed * Time.deltaTime);
        }
    }

    void _View()
    {
        if (view)
        {
            if (!view_init)
            {
                Debug.Log(wingTarget.arts[0].viewZone.bounds);
                artQ.Clear();
                pos_artQ = 0;
                for (int i = 0; i < wingTarget.installations.Count; i++)
                {
                    artQ.Add(wingTarget.installations[i]);
                }
                //go to the first art piece
                view_init = true;
            }else
            {
                if (pos_artQ < artQ.Count)
                {
                    transform.position = Vector3.Lerp(transform.position, artQ[pos_artQ].transform.position, speed * Time.deltaTime);
                    if (tick < timer)
                    {
                        
                        tick += 1 * Time.deltaTime;
                    }else
                    {
                        pos_artQ++;
                        tick = 0;
                    }
                }else
                {
                    
                    search = true;
                    view = false;
                    view_init = false;
                }
            }

            
        }
    }

    void _Search()
    {
        if (search)
        {
            float rando = Random.RandomRange(0, GM_guestScript.instance.Wings.Count);
            if (wingTarget == GM_guestScript.instance.Wings[Mathf.FloorToInt(rando)])
            {                
                return;           
            }else
            {
                wingTarget = GM_guestScript.instance.Wings[Mathf.FloorToInt(rando)];
                travel = true;
                search = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "entrance")
        {
            view = true;
            travel = false;
        }
    }
}
