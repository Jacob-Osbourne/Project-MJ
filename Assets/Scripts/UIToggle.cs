using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    private PlayerController pc;
    public GameObject chargeBarUI;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        chargeBarUI.SetActive(false);
        pc = FindObjectOfType<PlayerController>();
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
    }
}
