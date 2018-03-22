using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Art", menuName = "art")]
public class Art : ScriptableObject {

    public new string name;

    public string description;

	public string artist;

	public string Theme1;

	public string Theme2;

    public float baseScore; //baseline score
    public float cleanScore; //score added onto the baseline after cleaning
    

    public BoxCollider viewZone;
    public GameObject artObject;
	public Sprite view;
	public Sprite Restoreview;

    public bool researched;
    public bool restored;
	public bool displayed;

	public bool painting;

	public bool AR;
	public GameObject ARmodel;
	public Canvas dirtyspots;

    private void OnEnable()
    {
       // viewZone = artObject.GetComponent<BoxCollider>();
    }
}
