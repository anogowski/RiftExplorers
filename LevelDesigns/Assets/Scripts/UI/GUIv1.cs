using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIv1 : MonoBehaviour {

    public Image crossHair;

	// Use this for initialization
	void Start () 
    {
        setCrossHairVisable(false);
	}
	
	// Update is called once per frame
	void Update () {
	
    }

    public void setCrossHairVisable(bool visable)
    {
        crossHair.enabled = visable;
    }


}
