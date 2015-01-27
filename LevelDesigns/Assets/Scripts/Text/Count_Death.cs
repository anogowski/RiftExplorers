using UnityEngine;
using System.Collections.Generic;

public class Count_Death : DisplayText
{
    List<string> msg = new List<string>();
    string best = "";
    public void Start()
    {
        best += "Best Time:\t" + PlayerPrefs.GetInt("bestTime", 3600) + "\n";
        best += "Best Attempt(s):\t" + PlayerPrefs.GetInt("bestAttempts", 100) + "\n";
    }

    void Update()
    {
        string currentTime = "CurrentTime:\t" + WaterTempleManager.Instance.currentTime + "\n";
        string currentAttempts = "CurrentAttempt(s):\t" + WaterTempleManager.Instance.attempts + "\n";

        textToDisplay = best + currentTime + currentAttempts;
        textComponent.text = textToDisplay ;
    
    }

}
