using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour {

    public Vector3 destination;
    NavMeshAgent myAgent;

	// Use this for initialization
	void Start () {
        myAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        myAgent.SetDestination(destination);
		
	}
}
