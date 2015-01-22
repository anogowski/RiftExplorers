/************************************************************************************

 This class design is based on the Oculus VR OVRPlayerController
 All rights are reserved by Copyright of Oculus VR, LLC.

************************************************************************************/
#pragma warning disable 0414


using UnityEngine;
using System.Collections;

public class OVRController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateMovement()
    {
        bool moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool moveBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool run = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKey(KeyCode.Space);

        bool dpad_move = false;
    }
}
