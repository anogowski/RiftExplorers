﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour 
{
    public string textToDisplay;
    public Text textComponent;
    void Awake()
    {
        textComponent = GetComponent<Text>();
    }
    void Update()
    {
        textComponent.text = textToDisplay;
    }

}
