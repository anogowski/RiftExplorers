using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIv1 : MonoBehaviour {

    public Text message;
    public Text Timer;
    public Image crossHair;

	// Use this for initialization
	void Start () 
    {
        setCrossHairVisable(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTimer(string text)
    {
        Timer.text = text;
    }

    public void setMessage(string text)
    {
        message.text = text;
    }

    public void setCrossHairVisable(bool visable)
    {
        crossHair.enabled = visable;
    }


}
