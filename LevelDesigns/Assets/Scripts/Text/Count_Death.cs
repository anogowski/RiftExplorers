using UnityEngine;
using System.Collections.Generic;

public class Count_Death : DisplayText
{
    List<string> msg = new List<string>();
    void Update()
    {
        string bestTime = "Best Time:\t" + PlayerPrefs.GetInt("bestTime", 3600) + " seconds\n";
        string bestAttempt = "Best Attempt(s):\t" + PlayerPrefs.GetInt("bestAttempts", 100) + "\n";
        string currentTime = "Your Time:\t" + WaterTempleManager.Instance.currentTime + " seconds\n";
        string currentAttempts = "Your Attempt(s):\t" + WaterTempleManager.Instance.attempts;

        textToDisplay = bestTime + bestAttempt + currentTime + currentAttempts;
        textComponent.text = textToDisplay ;
    
    }

}
