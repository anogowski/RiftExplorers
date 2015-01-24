using UnityEngine;
using System.Collections;
using System;
using EventSystem;

public class GameManager : MonoBehaviour, EventSystem.EventListener
{

    int attempts = 1;
    int currentTime;
    int compeletionTime;
    int bestTime = 3600;
    public static Counter c = new Counter();
   public GameManager ()
    {

    }

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = c.currentTime.Seconds;
	}


    void EventListener.React(EventSystem.EventType eventType)
    {
        switch (eventType)
        {
            case EventSystem.EventType.Player_Death:
                attempts++;
                break;
            case EventSystem.EventType.Player_Alive:
                break;
            case EventSystem.EventType.Checkpoint:
                break;
            case EventSystem.EventType.Level_Start:
                bestTime = PlayerPrefs.GetInt("bestTime", 3600);
                break;
            case EventSystem.EventType.Level_Complete:
                {
                    compeletionTime =currentTime;
                    if (compeletionTime < bestTime)
                    {
                        bestTime = compeletionTime;
                        PlayerPrefs.SetInt("bestTime", bestTime);
                    }
                    PlayerPrefs.Save();
                    string[] lines = { "PlayerData", "Best Time: " + PlayerPrefs.GetInt("bestTime", 3600) };
                    System.IO.File.WriteAllLines(Application.persistentDataPath + "\\SaveFile.txt", lines);
                }
                break;
            case EventSystem.EventType.DoorOpen:
                break;
            case EventSystem.EventType.DoorClose:
                break;
            default:
                break;
        }
    }

 
}
