using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioController : MonoBehaviour
{
    public AudioSource s;

    // Update is called once per frame
    void Update()
    {
        if (SoundButtonController.muted == true)
        {
            s.volume = 0;
        }
        else
        {
            s.volume = 0.1f;
        }
    }
}
