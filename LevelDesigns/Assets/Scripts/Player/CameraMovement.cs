using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			this.transform.position -= new Vector3(1f, 0f, -1f);
		}
	}
}
