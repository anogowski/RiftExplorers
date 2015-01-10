﻿using UnityEngine;
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
			this.transform.position += new Vector3 (0f, 0.001f, 0f);
		}
		if(Appear.Triggered)
		{
			if(this.gameObject.name.Equals("Wave"))
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
			else 
			{
				Debug.Log (this.transform.position.y);
				if (this.transform.position.y < 0.695f)
				{
					this.transform.position += new Vector3(0.0f, 0.005f,0f);
				}
				else
				{
					this.transform.position = new Vector3 (0f, .695f, 0f);
				}
			}
		}
		if(this.gameObject.name.Equals("Wave"))
		{
			waterHeight = this.transform.position.y;
		}
	}
}
