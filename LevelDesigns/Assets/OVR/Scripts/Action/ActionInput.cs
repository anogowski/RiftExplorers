using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionInput : Singleton<ActionInput>
{

    public enum ActionsToTrack
    {
        jump,
        interact,
        fire,
        escape
    }

    private Dictionary<ActionsToTrack, bool> trackingActions;

    private void checkActions()
    {
        trackingActions[ActionsToTrack.jump]     = Input.GetKey(KeyCode.Space)  || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.A);
        trackingActions[ActionsToTrack.interact] = Input.GetKey(KeyCode.E)      || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.X);
        trackingActions[ActionsToTrack.fire]     = Input.GetMouseButtonDown(0)  || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1);
        trackingActions[ActionsToTrack.escape]   = Input.GetKey(KeyCode.Escape) || OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.Start);
    }

	// Use this for initialization
	void Start () {
        trackingActions = new Dictionary<ActionsToTrack, bool>();
        foreach (ActionsToTrack action in System.Enum.GetValues(typeof(ActionsToTrack)))
        {
            trackingActions.Add(action, false);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        checkActions();
	}

    /*
    void LateUpdate()
    {
        foreach (KeyValuePair<ActionsToTrack, bool> action in trackingActions)
        {
            trackingActions[action.Key] = false;
        }
    }
    */
    public bool checkAction(ActionsToTrack action)
    {
        return trackingActions[action];
    }
}
