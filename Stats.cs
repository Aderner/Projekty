﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float lerpSpeed;

    private Image content;
    [SerializeField]
    private Text statValue;

    private float currentFill;
     
   public float MyMaxValue { get; set; }
    
    private float currentValue;
    public float MyCurrentValue
    {
        get
        {
            return currentValue;                            
        }
        set
        {
           if (value > MyMaxValue)
           {
               currentValue = MyMaxValue;
           }
            else if(value < 0)
            {
                currentValue = 0;
            }
           else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;

            statValue.text = currentValue + "/" + MyMaxValue;
        }
    }


   
   
    // Start is called before the first frame update
    void Start()
    {
        MyMaxValue = 100;

        content = GetComponent<Image>();
        content.fillAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }
    public void Initialize (float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
