using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    private GameObject player;

    public float speed;
    public float offset = 0.5f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Move enemy towards player
        Vector3 dir = (transform.position - player.transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + dir * offset, Time.deltaTime * speed);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (player.transform.position - transform.position).normalized, 0.01f, 0.0f));
    }
}
