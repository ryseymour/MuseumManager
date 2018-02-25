﻿using System.Collections;
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
    public List<Art> artsQ = new List<Art>();

    public bool gVisible; //should model be visible
    public float invisTravelTimer; //timer to simulate travel
    float invisTick; //tick for travel simulation
    public float speed, patience, noise, timer, tick;

	// Use this for initialization
	void Start () {
        _Enter();
        view_init = false;
        invisTick = 0;
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

        if (GM_guestScript.instance.visible)
        {
            gVisible = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else{
            gVisible = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        _Travel();
        _View();
        _Search(); //need to be able to remember what they've already seen
        
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
            if (gVisible)
            {
                transform.position = Vector3.Lerp(this.transform.position, wingTarget.entrance.position, speed * Time.deltaTime);
            }else
            {
                if(invisTick < invisTravelTimer)
                {
                    invisTick += Time.deltaTime;
                }else
                {
                    Debug.Log("simulate collision");
                    view = true;
                    invisTick = 0;
                    travel = false;
                }
            }
            
        }
    }

    

    void _View()
    {
        if (view)
        {

            if (wingTarget.installations[0] == null) //if nothing is in the wing
            {
                //view_init = true;
                
                if (tick < timer) //timer based on patience
                {
                    tick += Time.deltaTime;
                    //make angry faces
                }
                else
                {
                    Debug.Log("nothing timer timed out       time");
                    //once they get fed up lower their overall score
                    tick = 0;
                    search = true;
                    view = false;                                   
                }
                return;
            }
            if (!view_init)
            {
                //Debug.Log(wingTarget.arts[0].viewZone.bounds);
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
                    if (gVisible)
                    {
                        transform.position = Vector3.Lerp(transform.position, artQ[pos_artQ].transform.position, speed * Time.deltaTime);
                    }else
                    {
                        //need a way to calculate the distance and the time it should take to travel to the exhibit, should be that final parameter in the lerp
                        //currently just fuck it and guest snaps to art position, should add an offset eventually
                        if(artQ[pos_artQ] != null)
                        {
                            transform.position = artQ[pos_artQ].transform.position;
                        }
                        
                    }
                    
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
                view_init = false;
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
