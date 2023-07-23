using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    bool isGrounded;
    float curPos;
    public Text scoreText;
    public static int score;
    public static int highestScore;
    // Start is called before the first frame update
    void Start()
    {
        curPos = 2.4f;
        score = 0;
        highestScore = Int32.Parse(PlayerPrefs.GetString("HighestScore"));
    }

    // Update is called once per frame
    void Update()
    {
        if(curPos < transform.position.y)
        {
            if (isGrounded)
            {
                curPos += 0.9f;
                score++;
            }
        }
        scoreText.text = "Score: " + score.ToString();
        if(score >= highestScore)
        {
            highestScore = score;
            saveHighestScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    void saveHighestScore()
    {
        PlayerPrefs.SetString("HighestScore", highestScore+"");
    }
}
