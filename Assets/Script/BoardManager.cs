using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    public GameObject wall;
    public GameObject door;
    Vector3 randomDoorPosition;
    // Use this for initialization
    void Start ()
    {
        randomDoorPosition = wall.transform.GetChild(Random.Range(0, wall.transform.childCount)).position;
        Instantiate(door, randomDoorPosition, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
