using UnityEngine;
using System.Collections;

public class SwitchTriggerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Hello");
		if(Appear.Triggered == false && ( other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer")))
		{
			Appear.Triggered = true;
		}
	}
}
