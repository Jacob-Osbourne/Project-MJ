using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayGamesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }

    void SignIn() 
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Success");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardID, long score)
    {
        Social.ReportScore(score, leaderboardID, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Score posted successfully");
            }
            else
            {
                Debug.Log("Score posted unsuccessfully");
            }
        });
    }

    public static void ShowLeaderboardsUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI7sOaxNYaEAIQAA");
    }
    #endregion /Leaderboards

}
