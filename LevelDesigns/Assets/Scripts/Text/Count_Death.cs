using UnityEngine;
using System.Collections.Generic;

public class Count_Death : DisplayText
{
    List<string> msg = new List<string>();
    void Update()
    {
        string bestTime = "Best Time:\t\t" + PlayerPrefs.GetInt("bestTimeWaterTemple", 3600) + " seconds\n";
        string bestAttempt = "Best Attempt(s):\t\t" + PlayerPrefs.GetInt("bestAttemptsWaterTemple", 100) + "\n";
        string currentTime = "Your Time:\t\t" + WaterTempleManager.Instance.currentTime + " seconds\n";
        string currentAttempts = "Your Attempt(s):\t\t" + WaterTempleManager.Instance.attempts;

        textToDisplay = bestTime + bestAttempt + currentTime + currentAttempts;
        textComponent.text = textToDisplay ; 
    
    }

}
