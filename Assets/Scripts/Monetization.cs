using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour
{

    string googlePlayID = "3986609";
    bool runAd = true;
    // Start is called before the first frame update


    void Awake()
    {
        Advertisement.Initialize(googlePlayID, runAd);
    }

    void Start()
    {
        StartCoroutine(RunInitialAd());
        ShowInterstitialAd();
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment");
        }
    }

    IEnumerator RunInitialAd()
    {
        yield return new WaitForSeconds(0.4f);
        Advertisement.Show();
    }
}
