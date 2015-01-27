using UnityEngine;
using System.Collections;

public class Count_Death :  DisplayText
{
    public void Start()
    {
        textToDisplay =  PlayerPrefs.GetInt("bestTime", 3600).ToString();
    }
}
