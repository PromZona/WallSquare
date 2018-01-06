using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

    public int LeftWallScore = 0;
    public int RightWallScore = 0;
    public GameObject CurBall;
    public GameObject BallPrefab;
    public Text LeftWallScoreText;
    public Text RightWallScoreText;


    // Use this for initialization
    void Start()
    {
        InitNewGame();
        UpdateScore();
    }
          
	
	// Update is called once per frame
	void Update ()
    {
        CurBall.GetComponent<BallMove>().speed += 0.008f;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void AddLeftWallScore()
    {
        Destroy(CurBall);
        LeftWallScore++;
        UpdateScore();
        InitNewGame();
    }

    public void AddRightWallScore()
    {
        Destroy(CurBall);
        RightWallScore++;      
        UpdateScore();
        InitNewGame();
    }

    public void InitNewGame()
    {
        CurBall = Instantiate(BallPrefab);
    }

    public void UpdateScore()
    {
        LeftWallScoreText.text = LeftWallScore.ToString();
        RightWallScoreText.text = RightWallScore.ToString();
    }
}
