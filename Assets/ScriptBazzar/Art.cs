using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Art", menuName = "art")]
public class Art : ScriptableObject {

    public new string name;

    public string description;

    public float cleanScore;
    public float totalScore;

    public BoxCollider viewZone;
    public GameObject artObject;

    public bool researched;
    public bool restored;

    private void OnEnable()
    {
       // viewZone = artObject.GetComponent<BoxCollider>();
    }
}
