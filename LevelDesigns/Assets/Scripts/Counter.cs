using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;
using EventSystem;
public class Counter : MonoBehaviour, EventSystem.EventListener {


    Stopwatch s = new Stopwatch();
    public TimeSpan currentTime;
    

	// Use this for initialization
	void Start ()
    {
	   
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentTime = s.Elapsed;
	}

    void EventListener.React(EventSystem.EventType eventType)
    {
        switch (eventType)
        {
            case EventSystem.EventType.Player_Death:
                s.Stop();
                break;
            case EventSystem.EventType.Player_Alive:
                s.Start();
                break;
            case EventSystem.EventType.Level_Start:
                s.Stop();
                break;
            case EventSystem.EventType.Level_Complete:
                s.Stop();
                    break;
            case EventSystem.EventType.Checkpoint:
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
