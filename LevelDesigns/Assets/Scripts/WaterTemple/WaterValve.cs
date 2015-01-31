using UnityEngine;
using System.Collections;
using EventSystem;
public class WaterValve : MonoBehaviour,IInteractable {

    EventSender sender = new EventSender();
	// Use this for initialization
	void Start ()
    {
        sender.Subscribe(WaterTempleManager.Instance);
	}
	
    public void interact(GameObject user)
    {
        Debug.Log("Interact With Valve");
        sender.SendEvent(EventSystem.EventType.Turn_Valve); 
    }
}
