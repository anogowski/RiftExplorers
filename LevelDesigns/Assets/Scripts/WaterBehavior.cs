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
			this.transform.position += new Vector3 (0f, 0.01f, 0f);
		}
		if(Appear.Triggered)
		{
			if(this.gameObject.name.Equals("Wave"))
			{
				if (this.transform.position.y < 38.75f)
				{
					this.transform.position += new Vector3(0.0f, 0.05f,0f);
				}
				else
				{
					this.transform.position = new Vector3 (0f, 38.75f, 0f);
				}
			}
			else 
			{
				if (this.transform.position.y < -7.25f)
				{
					this.transform.position += new Vector3(0.0f, 0.05f,0f);
				}
				else
				{
					this.transform.position = new Vector3 (0f, -7.25f, 0f);
				}
			}
		}
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
	}
}
