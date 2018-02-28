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

    public float cleanScore;
    public float totalScore;

    public BoxCollider viewZone;
    public GameObject artObject;
	public Sprite view;

    public bool researched;
    public bool restored;
	public bool displayed;

	public bool painting;

	public bool AR;

    private void OnEnable()
    {
       // viewZone = artObject.GetComponent<BoxCollider>();
    }
}
