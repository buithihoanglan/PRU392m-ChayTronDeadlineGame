using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour
{    public void PlayGame()
    {

        //Load scene
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene(1);
    }
}
