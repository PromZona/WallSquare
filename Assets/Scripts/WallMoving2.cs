using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving2 : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(6.745f, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 directionY = transform.up * 1;
            rb.velocity = directionY * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 directionY = transform.up * -1;
            rb.velocity = directionY * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
