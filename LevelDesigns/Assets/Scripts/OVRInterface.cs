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

    public GUIv1 guiInterface;

    private OVRCameraRig cameraRig;
    GameObject Left_Hand;
    GameObject Right_Hand;
    GameObject CenterEye;
    OVRPlayerController OVRContr;

    // Use this for initialization
    void Start()
    {
       cameraRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
       OVRContr  = this.transform.gameObject.GetComponent<OVRPlayerController>();
       Left_Hand = GameObject.FindGameObjectWithTag("Left_Hand");
       Right_Hand = GameObject.FindGameObjectWithTag("Right_Hand");
       CenterEye = GameObject.FindGameObjectWithTag("CenterEye");
    }

    public void pickUP(Hand hand, GameObject obj)
    {
        if (hand == Hand.Left)
        {
            obj.transform.parent = Left_Hand.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        else if(hand == Hand.right)
        {
            obj.transform.parent = Left_Hand.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyboardInput();
        movement();
    }

    private void keyboardInput()
    {
        bool escape = ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.escape);
        if(escape)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

    public Vector3 getForward()
    {
        //return cameraRig.centerEyeAnchor.forward;
        Vector3 forward = CenterEye.transform.forward;
        Debug.Log("Forward Vector 3: " + forward);
        return forward;
    }

    public Vector3 getPosition()
    {
        return CenterEye.transform.position;
    }

    //Interface to OVR Controller
    private void movement()
    {
        if (ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.jump))
        {
            OVRContr.Jump();
        }
    }
}
