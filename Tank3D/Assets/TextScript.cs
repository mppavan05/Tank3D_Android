using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI text;
    private void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        EventManager.ExampleEvent += Welcometext;
    }

    private void Update()
    {
        //Welcometext();
        
    }

    private void Welcometext()
    {
        count++;
        text.color = Color.black;
        text.fontStyle = (FontStyles)FontStyle.Bold;
        
        text.text = "Bullet fired is:-" + count;
        if(count == 10)
        {
            text.color = Color.green;
            text.text = "10 Bullets fired";
        }
        if (count == 25)
        {
            text.color = Color.yellow;
            
            text.text = "25 Bullets fired";
        }
        if (count == 50)
        {
            text.color = Color.red;
            
            text.text = "50 Bullets fired";
        }
    }

    private void OnDisable()
    {
        
        EventManager.ExampleEvent -= Welcometext;
    }

    public void GetTextEvent()
    {
         Welcometext();
    }
}
