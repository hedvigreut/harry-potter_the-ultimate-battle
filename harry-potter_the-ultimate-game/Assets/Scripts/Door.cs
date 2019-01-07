using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private GameObject player;

    public float speed;
    public float offset = 0.5f;
    public float floorOffset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //Move enemy towards player
        Vector3 dir = (transform.position - player.transform.position).normalized;
        transform.localPosition = Vector3.MoveTowards(transform.position, player.transform.position + dir * offset, Time.deltaTime * speed);
        //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (player.transform.position - transform.position).normalized, 0.01f, 0.0f));
    }
}
