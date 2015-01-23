using UnityEngine;
using System.Collections;

public class TempDoorToMaze : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer"))
        {
            Debug.Log("ToTheMaze");
            Application.LoadLevel("MazeRoom");
        }
    }
}
