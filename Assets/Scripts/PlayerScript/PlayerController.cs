using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameOver gameOver;
    
    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.y - transform.position.y > 7f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver.SetUp(ScoreController.score);
    }
}
