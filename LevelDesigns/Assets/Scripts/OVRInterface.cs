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
    public float speed;

    public GUIv1 guiInterface;

    private OVRCameraRig cameraRig;
    GameObject Left_Hand;
    GameObject Right_Hand;
    GameObject CenterEye;
    GameObject editorCam;
    OVRPlayerController OVRContr;

    private float yPos;

    // Use this for initialization
    void Start()
    {
        cameraRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
        OVRContr  = this.transform.gameObject.GetComponent<OVRPlayerController>();
        Left_Hand = GameObject.FindGameObjectWithTag("Left_Hand");
        Right_Hand = GameObject.FindGameObjectWithTag("Right_Hand");
        CenterEye = GameObject.FindGameObjectWithTag("CenterEye");
        editorCam = GameObject.FindGameObjectWithTag("EditorCam");
        yPos = this.transform.position.y;

        #if UNITY_EDITOR
                EditorTesting(true);
        #else
                EditorTesting(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        keyboardInput();
        movement();
        #if UNITY_EDITOR
            applyMouseRotation();
        #endif
    }

    public bool getFallDeath()
    {
        bool fallDeath = false;
        if (isFalling())
        {
            Debug.Log("I have fallen and I can't get up.");
            fallDeath = true;
        }
        return fallDeath;
    }

    public bool isFalling()
    {
        if (OVRContr.isGrounded())
        {
            float length = Mathf.Abs(yPos - this.transform.position.y);
            if (length > 30f && (yPos > this.transform.position.y))
            {
                return true;
            }
            else
            {
                yPos = this.transform.position.y;
            }
        }
        return false;
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

    private void applyMouseRotation()
    {
        float axisX = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightXAxis);
        float axisY = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightYAxis);
        
        cameraRig.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * speed);
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * (2 * speed));
    }

    private void EditorTesting(bool inEditor)
    {
        if (inEditor)
        {
            editorCam.SetActive(true);
            cameraRig.leftEyeAnchor.gameObject.SetActive(false);
            cameraRig.rightEyeAnchor.gameObject.SetActive(false);
            Debug.Log("Playing in Editor");
        }
        else
        {
            editorCam.SetActive(false);
            Debug.Log("Playing in Game");
        }
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
