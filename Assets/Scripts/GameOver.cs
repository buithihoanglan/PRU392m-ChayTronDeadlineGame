using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreTxt;
    public TextMeshProUGUI btnTxt;
    public TextMeshProUGUI btnRestartTxt;
    public void SetUp(int Score)
    {
        gameObject.SetActive(true);
        scoreTxt.text = "Score: " + Score.ToString();
        btnTxt.text = "Home";
        btnRestartTxt.text = "Restart";
    }

    public void toHome()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
