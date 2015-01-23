using UnityEngine;
using System.Collections;

public class MazeDeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer"))
        {
            Application.LoadLevel("MazeRoom");
        }
    }
}
