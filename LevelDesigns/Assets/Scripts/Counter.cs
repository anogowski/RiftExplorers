using UnityEngine;
using System.Collections;
using System.Diagnostics;
using EventSystem;
public class Counter : MonoBehaviour, EventSystem.EventListener {


    static Stopwatch s = new Stopwatch();
    public int currentTime;
    	
	// Update is called once per frame
	public void Update() 
    {
        currentTime =s.Elapsed.Seconds;
        UnityEngine.Debug.Log(currentTime);
	}

    void EventListener.React(EventSystem.EventType eventType)
    {
        switch (eventType)
        {
            case EventSystem.EventType.Player_Alive:
               UnityEngine.Debug.Log("Start Timer");
                s.Start();
                break;
            case EventSystem.EventType.Player_Death:
                s.Stop();
                break;
            case EventSystem.EventType.Level_Complete:
                s.Stop();
                break;
            default:
                break;
        }
    }

}
