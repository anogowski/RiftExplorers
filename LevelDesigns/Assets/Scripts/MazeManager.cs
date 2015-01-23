using UnityEngine;
using System.Collections;

public class MazeManager : GameManager {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    void OnGUI()
    {
        GUI.Button(new Rect(500, 500, 200, 40), "CurrentSpeed for X: ");
        GUI.Button(new Rect(500, 550, 200, 40), "CurrentSpeed for Y: ");
    }
}
