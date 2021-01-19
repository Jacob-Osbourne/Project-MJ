using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
