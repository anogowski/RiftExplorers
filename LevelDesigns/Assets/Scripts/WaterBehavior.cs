using UnityEngine;
using System.Collections;

public class WaterBehavior : MonoBehaviour {

	public static float waterHeight = -1f;
	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
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
                    AudioManager.Instance.StopSound(WaterTempleManager.Instance.water);           
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
