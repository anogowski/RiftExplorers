using UnityEngine;
using System.Collections;

public class SwitchTriggerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Hello");
		if(Appear.Triggered == false && other.gameObject.name.Equals("Player"))
		{
			Appear.Triggered = true;
		}
	}
}
