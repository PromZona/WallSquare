using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour {

    public float speed = 0.02f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //transform.position = new Vector3(-6.72f, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.W))
        {            
            Vector3 directionY = transform.up * 1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + directionY, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 directionY = transform.up * -1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + directionY, speed * Time.deltaTime);
        }
	}
}
