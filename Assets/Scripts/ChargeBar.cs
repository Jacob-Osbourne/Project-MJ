using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    private PlayerController pc;
    public Gradient gradient;
    public UnityEngine.UI.Image chargeFill;
    public GameObject chargeBar;
    public Slider slider;

    public Text chargePercent;

   
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        gradient.Evaluate(pc.chargePower);
    }

    // Update is called once per frame
    void Update()
    {

        slider.maxValue = pc.maxCharge;
        slider.value = pc.chargePower;
        chargeFill.color = gradient.Evaluate(slider.normalizedValue);

        chargePercent.text = ((pc.chargePower/2) * 100f).ToString("F0") + "%";
        if (pc.chargePower > 2)
        {
            chargePercent.text = "100%";
        }
    }

    
}
