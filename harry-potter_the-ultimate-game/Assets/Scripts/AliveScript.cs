using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveScript : MonoBehaviour
{

    Vector3 startingPos;
    float speed = 0.5f; //how fast it shakes
    float amount = 0.05f; //how much it shakes

    // Use this for initialization
    void Start()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        startingPos.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = new Vector3(startingPos.x + (Mathf.Sin(Time.time * speed) * amount), startingPos.y + ((Mathf.Sin(Time.time * speed) * amount)), startingPos.z + ((Mathf.Sin(Time.time * speed) * amount)));



    }

}
