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
        MouseLook.Instance.setRotation(this.transform.localRotation);

        //EditorTesting(false);
        #if UNITY_EDITOR
                //EditorTesting(true);
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


    private void applyMouseRotation()
    {
        float xAxis = 0.0f;
        float yAxis = 0.0f;

        /**
        xAxis = Input.GetAxis("Mouse X");
        yAxis = Input.GetAxis("Mouse Y");
        /**/

        /**/
        xAxis = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightXAxis);
        yAxis = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightYAxis);
        /**/

        /**
        cameraRig.transform.Rotate(MouseLook.Instance.classicGetRotation() * speed);
        this.transform.Rotate(MouseLook.Instance.classicGetRotationX() * Time.deltaTime * (2 * speed));
        /**/

        /**/
        cameraRig.transform.Rotate(new Vector3(-yAxis, 0, 0) * Time.deltaTime * speed);
        this.transform.Rotate(new Vector3(0, xAxis, 0) * Time.deltaTime * (2 * speed));
        /**/

        /**
        cameraRig.transform.localRotation = (MouseLook.Instance.getRotation());
        this.transform.localRotation = (MouseLook.Instance.getRotationY());
        /**/

    }


    public bool getFallDeath()
    {
        bool fallDeath = false;
        if (isFalling())
        {
            //Debug.Log("I have fallen and I can't get up.");
            fallDeath = true;
            yPos = this.transform.position.y;
        }
        return fallDeath;
    }

    public bool isFalling()
    {
        if(FadingManager.fadingOut)
        {
            yPos = -52.2f;
        }
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

    private void EditorTesting(bool inEditor)
    {
        if (inEditor)
        {
            editorCam.SetActive(true);
            cameraRig.leftEyeAnchor.gameObject.SetActive(false);
            cameraRig.rightEyeAnchor.gameObject.SetActive(false);
            //Debug.Log("Playing in Editor");
        }
        else
        {
            Debug.Log("Playing in Game");
        }
    }

    private void keyboardInput()
    {
        bool escape = ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.Escape);
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
        if (ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.Jump))
        {
            OVRContr.Jump();
        }
    }
}
