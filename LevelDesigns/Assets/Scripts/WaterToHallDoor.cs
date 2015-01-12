using UnityEngine;
using System.Collections;

public class WaterToHallDoor : MonoBehaviour {

    public GameObject doorToHall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(SceneFadeInOut.sceneFade)
        {
            doorToHall.transform.position += new Vector3(0f, 0.001f, 0f);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer") &&
            (Appear.Triggered))
        {
            SceneFadeInOut.sceneFade = true;
        }
        
    }
}
