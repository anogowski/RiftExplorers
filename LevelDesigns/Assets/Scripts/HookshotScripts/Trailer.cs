using UnityEngine;
using System.Collections;

public class Trailer : MonoBehaviour {

    public GameObject  Tracking;
    private Vector3    lastPosition;
    private Quaternion lastRotation;

	// Use this for initialization
	void Start () {
        Tracking = GameObject.FindGameObjectWithTag("Hook");
        lastPosition = Tracking.transform.position;
        lastRotation = Tracking.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        trackPosition();
        trackRotation();
	}

    private void trackPosition()
    {
        Vector3 currentPost = Tracking.transform.position;
        Vector3 diffrence = currentPost - lastPosition;
        this.transform.position += diffrence;
        lastPosition = currentPost;
    }

    private void trackRotation()
    {
        //Quaternion currentRotation = Tracking.transform.localRotation;
        //Quaternion diffrence = currentRotation - lastRotation;
        this.transform.rotation = Tracking.transform.localRotation;
    }
}
