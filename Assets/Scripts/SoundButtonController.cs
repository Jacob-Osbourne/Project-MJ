using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonController : MonoBehaviour
{
    public static bool muted = false;
    public GameObject MuteButton;
    public GameObject UnmuteButton;

    public void MuteGame()
    {
        muted = true;
    }

    public void UnmuteGame()
    {
        muted = false;
    }

    private void Update()
    {
        if (muted)
        {
            UnmuteButton.SetActive(true);
            MuteButton.SetActive(false);
        }
        else
        {
            UnmuteButton.SetActive(false);
            MuteButton.SetActive(true);
        }
    }
}
