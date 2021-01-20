using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public PlayerController pc;
    public float playerScore;
    public float scoreMax;
    public float currentScore;
    public Text playerScoreText;
    public Text onDeathScore;
    public Text onDeathHighScore;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        //scoreMax =  0f;
    }

    // Update is called once per frame
    void Update()
    {
       

        playerScore = (pc.transform.position.x + 5f)/2;


        if (scoreMax < playerScore)
        {
            playerScoreText.text = scoreMax.ToString("F0");
            scoreMax = playerScore;
            currentScore = playerScore;          
        }

        onDeathScore.text = "Score: " + PlayerPrefs.GetFloat("currentScore").ToString("F0");
        onDeathHighScore.text = "Best: " + PlayerPrefs.GetFloat("HighScore").ToString("F0");
    }

     
}
