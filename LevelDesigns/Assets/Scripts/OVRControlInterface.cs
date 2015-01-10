using UnityEngine;
using System.Collections;

public class OVRControlInterface : MonoBehaviour {

    //public GameObject player;

    public float rotationRachet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool jump    = Input.GetKey( KeyCode.Space );
        bool rotateR = Input.GetKey( KeyCode.E     );
        bool rotateL = Input.GetKey( KeyCode.Q     );

        OVRPlayerController OVRContr = gameObject.GetComponent("OVRPlayerController") as OVRPlayerController;

        if (jump)
        {
            OVRContr.Jump();
        }

        if (rotateR)
        {
            OVRContr.YRotation += rotationRachet;
            //Debug.Log("rotateR");
        }

        if (rotateL)
        {
            OVRContr.YRotation -= rotationRachet;
           // Debug.Log("rotateL");
        }

	}
}
