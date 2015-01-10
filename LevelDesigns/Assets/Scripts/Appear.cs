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
		if(Input.GetKeyUp("1"))
		{
			prefab.SetActive (false);
		}
		if(Input.GetKeyUp("2"))
		{
			prefab.SetActive (true);
		}
		if(Triggered)
		{
			prefab.SetActive(true);
		}
	}
}
