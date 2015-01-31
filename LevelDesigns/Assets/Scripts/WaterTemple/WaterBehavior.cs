using UnityEngine;
using System.Collections;
using EventSystem;

public class WaterBehavior : MonoBehaviour {

	public static float waterHeight = -1f;
    private bool isFilled = false;
    EventSender eventSender = new EventSender();

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
        eventSender.Subscribe(WaterTempleManager.Instance);
	}
	
	// Update is called once per frame
	void Update () {
		if(!Appear.Triggered)
		{
			this.transform.position += new Vector3 (0f, 0.005f, 0f);
		}
		if(Appear.Triggered)
		{
			if(this.gameObject.name.Equals("Wave"))
			{
				if (this.transform.position.y < 39f)
				{
					this.transform.position += new Vector3(0.0f, 0.1f,0f);
				}
				else
				{                               
                    if (!isFilled)
                    {
                        isFilled = true;
                        eventSender.SendEvent(EventSystem.EventType.Valve_Closed);
                    }
					this.transform.position = new Vector3 (0f, 39f, 0f);
				}
			}
			else 
			{
				if (this.transform.position.y < -7f)
				{
					this.transform.position += new Vector3(0.0f, 0.1f,0f);
				}
				else
				{
					this.transform.position = new Vector3 (0f, -7f, 0f);
				}
			}
		}
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
	}
}
