using UnityEngine;
using System.Collections;

public class Appear : MonoBehaviour {

	public static bool Triggered = false;
	public GameObject prefab;
	// Use this for initialization
	void Start () 
	{
		prefab.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (WaterBehavior.waterHeight == 10.8f && Triggered)
		{
			prefab.SetActive(true);
		}
	}
}
