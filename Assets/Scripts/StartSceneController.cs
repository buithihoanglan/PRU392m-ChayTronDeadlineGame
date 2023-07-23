using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    public TextMeshProUGUI highestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highestScoreText.text = "Highest Score: " + PlayerPrefs.GetString("HighestScore");
    }
}
