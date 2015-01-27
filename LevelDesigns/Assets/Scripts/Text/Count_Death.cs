using UnityEngine;
using System.Collections.Generic;

public class Count_Death : DisplayText
{
    List<string> msg = new List<string>();
    string best = "";
    public void Start()
    {
        best += "Best Time:\t" + PlayerPrefs.GetInt("bestTime", 3600) + " seconds\n";
        best += "Best Attempt(s):\t" + PlayerPrefs.GetInt("bestAttempts", 100) + "\n";
    }

    void Update()
    {
        string currentTime = "Your Time:\t" + WaterTempleManager.Instance.currentTime + " seconds\n";
        string currentAttempts = "Your Attempt(s):\t" + WaterTempleManager.Instance.attempts;

        textToDisplay = best + currentTime + currentAttempts;
        textComponent.text = textToDisplay ;
    
    }

}
