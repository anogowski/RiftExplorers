using UnityEngine;
using System.Collections;
using System;
using EventSystem;

public class GameManager : MonoBehaviour, EventSystem.EventListener
{

    int attempts = 1;
    TimeSpan currentTime;
    TimeSpan compeletionTime;
    TimeSpan bestTime = TimeSpan.FromHours(1);
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
        currentTime = c.currentTime;
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
            case EventSystem.EventType.Level_Complete:
                {
                    compeletionTime =currentTime;
                    if (compeletionTime < bestTime)
                    {
                        bestTime = compeletionTime;
                    }
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
