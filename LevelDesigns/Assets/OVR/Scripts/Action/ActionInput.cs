using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionInput : Singleton<ActionInput>
{

    public enum ActionsToTrack
    {
        Jump,
        Interact,
        Fire,
        Escape,
        Sprint
    }

    private Dictionary<ActionsToTrack, bool> trackingActions;

    // Use this for initialization
    void Start()
    {
        trackingActions = new Dictionary<ActionsToTrack, bool>();
        foreach (ActionsToTrack action in System.Enum.GetValues(typeof(ActionsToTrack)))
        {
            trackingActions.Add(action, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkActions();
    }


    private void checkActions()
    {
        trackingActions[ActionsToTrack.Jump]     = Input.GetKey(KeyCode.Space)     || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.A);
        trackingActions[ActionsToTrack.Interact] = Input.GetKey(KeyCode.E)         || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.X);
        trackingActions[ActionsToTrack.Fire]     = Input.GetMouseButtonDown(0)     || (OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightTrigger) > 0.0f);
        trackingActions[ActionsToTrack.Escape]   = Input.GetKey(KeyCode.Escape)    || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.Start);
        trackingActions[ActionsToTrack.Sprint]   = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.LeftShoulder);
    }

    public bool checkAction(ActionsToTrack action)
    {
        return trackingActions[action];
    }
}
