using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public float speed = 4.0f;

    public Control Control;
    public GameObject LeftWall;
    public GameObject RightWall;

    bool GOAL = false;
    Rigidbody2D rb;
    Vector3 Direction = new Vector3(-1, 0);

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Control = FindObjectOfType<Control>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = Direction * speed;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, speed * Time.deltaTime);
       // Debug.Log(Direction);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        

        //Врезаемся в правую стену
        if (other.gameObject.tag == "RightWall")
        {
            float multiplication = 0;
            float dirX = 0;
            float dirY = 0;

            if (transform.position.y > other.gameObject.transform.position.y)
            {
                multiplication = 0.8f - (transform.position.y - other.gameObject.transform.position.y);
                dirY = 1 - multiplication - 0.2f;
                dirX = -(1 - dirY);
            }
            
            if (transform.position.y < other.gameObject.transform.position.y)
            {
                multiplication = 0.8f - (other.gameObject.transform.position.y - transform.position.y);
                dirY = -(1 - multiplication - 0.2f);
                dirX = -(1 + dirY);
            }

            if (transform.position.y == other.gameObject.transform.position.y)
            {
                dirX = -1;
                dirY = 0;
            }

            Direction = new Vector3(dirX, dirY);
        }

        //Врезаемся в левую стену
        if (other.gameObject.tag == "LeftWall")
        {
            float multiplication = 0;
            float dirX = 0;
            float dirY = 0;

            if (transform.position.y > other.gameObject.transform.position.y)
            {
                multiplication = 0.8f - (transform.position.y - other.gameObject.transform.position.y);
                dirY = 1 - multiplication - 0.2f;
                dirX = 1 - dirY;
            }

            if (transform.position.y < other.gameObject.transform.position.y)
            {
                multiplication = 0.8f - (other.gameObject.transform.position.y - transform.position.y);
                dirY = -(1 - multiplication - 0.2f);
                dirX = 1 + dirY;
            }

            if (transform.position.y == other.gameObject.transform.position.y)
            {
                dirX = 1;
                dirY = 0;
            }

            Direction = new Vector3(dirX, dirY);
        }

        if (other.gameObject.tag == "TopWall" || other.gameObject.tag == "BottomWall")
        {
            Direction.y = -Direction.y;
        }

        if (other.gameObject.tag == "LeftZone" && !GOAL)
        {
            GOAL = true; 
            Control.AddRightWallScore();            
        }

        if (other.gameObject.tag == "RightZone" && !GOAL)
        {
            GOAL = true;
            Control.AddLeftWallScore();
        }
    }
}
