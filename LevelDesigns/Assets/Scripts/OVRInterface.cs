using UnityEngine;
using System.Collections;

public class OVRInterface : MonoBehaviour
{

    public float rotationRachet;

    private OVRCameraRig cameraRig;
    OVRPlayerController OVRContr;

    // Use this for initialization
    void Start()
    {
        cameraRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
       OVRContr = this.transform.gameObject.GetComponent<OVRPlayerController>();
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
