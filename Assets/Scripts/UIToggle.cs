using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    private PlayerController pc;
    public GameObject chargeBarUI;
    public GameObject onDeathUI;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
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
}
