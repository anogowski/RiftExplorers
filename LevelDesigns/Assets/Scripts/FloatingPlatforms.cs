using UnityEngine;
using System.Collections;

public class FloatingPlatforms : MonoBehaviour {

	public static float height = -1.0f;
	// Use this for initialization
	void Start () 
	{
		this.transform.position.y = height;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!Appear.Triggered)
		{
			if (this.transform.position.y < 3.15f)
			{
				this.transform.position += new Vector3 (0f, 0.001f, 0f);
			}
			else
			{
				this.transform.position = new Vector3 (0f, 3.15f, 0f);
			}
		}
		else
		{
			if (this.transform.position.y < 3.15f)
			{
				this.transform.position += new Vector3(0.0f, 0.05f,0f);
			}
			else
			{
				this.transform.position = new Vector3 (0f, 3.15f, 0f);
			}
		}
	}
}
