using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    private PlayerController pc;
    public GameObject chargeBarUI;
    public GameObject onDeathUI;
    public GameObject FirstToggle1UI;
    public GameObject FirstToggle2UI;

    private void Awake()
    {
        FirstToggle1UI.SetActive(false);
        FirstToggle2UI.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstPlay") != 1)
        {
            FirstToggle1UI.SetActive(true);
        }
        chargeBarUI.SetActive(false);
        pc = FindObjectOfType<PlayerController>();
        onDeathUI.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (pc.chargePower > 0)
        {
            chargeBarUI.SetActive(true);
        }

        if (pc.chargePower == 0)
        {
            chargeBarUI.SetActive(false);
        }

        if (pc.isDead)
        {
            onDeathUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void FirstPlay1()
    {
        FirstToggle1UI.SetActive(false);
        FirstToggle2UI.SetActive(true);
    }

    public void FirstPlay2()
    {
         FirstToggle2UI.SetActive(false);
         PlayerPrefs.SetInt("FirstPlay", 1);
    }

}
