using UnityEngine;
using System.Collections;
using EventSystem;

public class WaterBehavior : MonoBehaviour {

	public static float waterHeight = -1f;
    private bool isFilled = false;
    EventSender eventSender = new EventSender();
    private GameObject player;

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;         
		}
        player = GameObject.Find("OVRPlayer");
        eventSender.Subscribe(WaterTempleManager.Instance);
	}
	
	// Update is called once per frame
	void Update () {
		if(!Appear.Triggered)
		{
            //platforms
            if (player.transform.position.y < -40f)
            {
                this.transform.position += new Vector3(0f, 0.005f, 0f);
            }
            else
            {
                this.transform.position += new Vector3(0f, 0.01f, 0f);
            }
            

            //while hookshotting
            if(player.transform.position.y > -40f && player.transform.position.y < 1.5f)
            {
                this.transform.position += new Vector3(0f, 0.21f, 0f);
            }
            if (player.transform.position.y > 16f && player.transform.position.y < 43f)
            {
                this.transform.position += new Vector3(0f, 0.15f, 0f);
            }
            if (player.transform.position.y > 68f && player.transform.position.y < 81f)
            {
                this.transform.position += new Vector3(0f, 0.15f, 0f);
            }
            if (player.transform.position.y > 97.5f && player.transform.position.y < 130f)
            {
                this.transform.position += new Vector3(0f, 0.2f, 0f);
            }

		}
		if(Appear.Triggered)
		{
			if(this.gameObject.name.Equals("Wave"))
			{
				if (this.transform.position.y < 137f)
				{
					this.transform.position += new Vector3(0.0f, 0.25f,0f);
				}
				else
				{                               
                    if (!isFilled)
                    {
                        isFilled = true;
                        eventSender.SendEvent(EventSystem.EventType.Valve_Closed);
                    }
					this.transform.position = new Vector3 (0f, 137f, 0f);
				}
			}
			else 
			{
				if (this.transform.position.y < 42f)
				{
					this.transform.position += new Vector3(0.0f, 0.25f,0f);
				}
				else
				{
					this.transform.position = new Vector3 (0f, 42f, 0f);
				}
			}
		}
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
	}
}
