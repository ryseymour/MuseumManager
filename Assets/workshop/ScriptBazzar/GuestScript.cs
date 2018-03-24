﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuestScript : MonoBehaviour {


    public bool enter, travel, search, view, use, exit, active;
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
    public float speed, patience, noise, timer, tick, score;

    public GameObject exitDoor; 

    int wingCount; //how many wings have you visited
    public int wingCount_Max; //


    NavMeshAgent myAgent;
	// Use this for initialization
	void Start () {
        _Enter();
        view_init = false;
        invisTick = 0;
        myAgent = GetComponent<NavMeshAgent>();        
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

        if (GM_guestScript.instance.visible) //is there an open menu?
        {
            if (gVisible) //is this model active in the scene?
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }else //are they in their weird purgatory
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
           
        }
        else{             //a window is open, stop looking at the guests
            this.GetComponent<MeshRenderer>().enabled = false; 
        }

        if (active)
        {
            _Travel();
            _View();
            _Search(); //need to be able to remember what they've already seen
            _Leave();
        }

        
	}

    void _Enter()
    {
        if (enter)
        {
            transform.position = exitDoor.transform.position;
            active = true;
            score = 0;
            wingCount = 0;
            float rando = Random.Range(0, GM_guestScript.instance.Wings.Count);
            wingTarget = GM_guestScript.instance.Wings[Mathf.FloorToInt(rando)];           
            travel = true;
            enter = false;
            exit = false;
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
               // transform.position = Vector3.Lerp(this.transform.position, wingTarget.entrance.position, speed * Time.deltaTime);
                myAgent.SetDestination(wingTarget.entrance.position);
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

            if (wingTarget.installations[0] == null || wingTarget.installations.Count == 0) //if nothing is in the wing
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
                        //transform.position = Vector3.Lerp(transform.position, artQ[pos_artQ].transform.position, speed * Time.deltaTime);
                        myAgent.SetDestination(artQ[pos_artQ].transform.position);
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
                        Debug.Log(artQ[pos_artQ]);
                        score += artQ[pos_artQ].GetComponent<ArtInstallation>().myArt.baseScore + artQ[pos_artQ].GetComponent<ArtInstallation>().myArt.cleanScore;
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
                if(wingCount < wingCount_Max)
                {
                    wingCount++;
                    wingTarget = GM_guestScript.instance.Wings[Mathf.FloorToInt(rando)];
                    travel = true;                   
                    search = false;
                    view_init = false;
                }
                else
                {
                    exit = true;
                    travel = false;
                    search = false;
                }
            }
        }

    }

    void _Leave()
    {
        if (exit)
        {
            //transform.position = Vector3.Lerp(this.transform.position, exitDoor.transform.position, speed * Time.deltaTime);
            myAgent.SetDestination(exitDoor.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("init " + other.name);
        if(other.tag == "entrance")
        {
            Debug.Log(other.name);
            view = true;
            travel = false;
        }

        if (other.tag == "exit")
        {
            if (exit)
            {
                GameObject.Find("GM").GetComponent<UI_Manager>().donateMax += score;
                GameObject.Find("GM").GetComponent<UI_Manager>().donateText.text = "Donations: $" + GameObject.Find("GM").GetComponent<UI_Manager>().donateMax;
                exit = false;
                gVisible = false;
                Debug.Log(score);
                int i = GM_guestScript.instance.GuestPool.IndexOf(this.gameObject);
                GM_guestScript.instance.DeActivate(i);
                active = false;


            }

        }
    }
}
