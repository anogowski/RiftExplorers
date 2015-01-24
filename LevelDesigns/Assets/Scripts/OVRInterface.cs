using UnityEngine;
using System.Collections;

public enum Hand
{
    Left,
    right
}

public class OVRInterface : MonoBehaviour
{

    public float rotationRachet;

    private OVRCameraRig cameraRig;
    GameObject Left_Hand;
    GameObject Right_Hand;
    OVRPlayerController OVRContr;

    // Use this for initialization
    void Start()
    {
       cameraRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
       OVRContr  = this.transform.gameObject.GetComponent<OVRPlayerController>();
       Left_Hand = GameObject.FindGameObjectWithTag("Left_Hand");
       Right_Hand = GameObject.FindGameObjectWithTag("Right_Hand");
    }

    public void pickUP(Hand hand, GameObject obj)
    {
        if (hand == Hand.Left)
        {
            obj.transform.parent = Left_Hand.transform;
        }
        else if(hand == Hand.right)
        {
            obj.transform.parent = Left_Hand.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public Vector3 getForward()
    {
        return cameraRig.centerEyeAnchor.forward;
    }

    //Interface to OVR Controller
    private void movement()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        bool rotateR = Input.GetKey(KeyCode.E);
        bool rotateL = Input.GetKey(KeyCode.Q);

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
