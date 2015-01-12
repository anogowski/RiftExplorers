using UnityEngine;
using System.Collections;

public class ClosingDoor : MonoBehaviour {

    private bool closing = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
    //Need to think of another solution.
	void Update () {
        if (!closing && this.transform.position.y > 3.5f)
        {
            Debug.Log("HERE");
            this.transform.position = new Vector3(5.005f, 4f, -0.8f);
            closing = true;
        }
        while(closing)
        {
            this.transform.position -= new Vector3(0f, -0.01f, 0f);
            if(this.transform.position.y < 3.5f)
            {
                this.transform.position = new Vector3(5.005f, 3.5f, -0.8f);
                closing = false;
            }
        }
	}
}
