using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.W))
        {           
            Vector3 directionY = transform.up * 1;
            rb.velocity = directionY * speed;
            //transform.position = Vector3.MoveTowards(transform.position, transform.position + directionY, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 directionY = transform.up * -1;
            rb.velocity = directionY * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector2.zero;           
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = Vector2.zero;
        }

    }
}
