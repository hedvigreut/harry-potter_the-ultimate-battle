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
            Debug.Log("SOUL");
            playingObject.transform.localScale = new Vector3(2f, 2f, 2f);
            playingObject.transform.position= new Vector3(0, 0, 0);
            //playingObject.transform.Translate(0, 0, 0);
        } else if (playingObject.tag == "Monster")
        {
            Debug.Log("MONSTER");
            playingObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            playingObject.transform.position = new Vector3(0, 0, 0);
            // playingObject.transform.Translate(0,0,0);

        } else if (playingObject.tag == "Door")
        {
            Debug.Log("DOOR");
            playingObject.transform.localScale = new Vector3(1f, 1f, 1f);
            playingObject.transform.position = new Vector3(0, 2, 0);
            //playingObject.transform.Translate(0, 0, 0);
        }

        Instantiate(playingObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
