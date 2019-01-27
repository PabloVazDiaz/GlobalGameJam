﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Image clock;
    public Image slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillClock(float amount)
    {
        clock.fillAmount += amount;
        if (clock.fillAmount >= 1)
        {
            clock.fillAmount = 0;
        }
    }

    public void UpdateSlider(float amount)
    {
        slider.fillAmount = amount;
    }

}
