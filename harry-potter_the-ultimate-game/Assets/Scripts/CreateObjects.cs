//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {

    public GameObject Soulsucker;
    public GameObject Monster;
    public GameObject Door;

    List<GameObject> objectNameList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        objectNameList.Add(Soulsucker);
        objectNameList.Add(Monster);
        objectNameList.Add(Door);

        Random rnd = new Random();
        int arrayNumber = Random.Range(0, 3);

        GameObject playingObject = objectNameList[arrayNumber];

        if (playingObject.tag == "Soul")
        {
            playingObject.transform.localScale = new Vector3(2f, 2f, 2f);
        } else if (playingObject.tag == "Monster")
        {
            playingObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        } else if (playingObject.tag == "Door")
        {
            playingObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        Instantiate(playingObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
