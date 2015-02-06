using UnityEngine;
using System.Collections;

public class CollitionScript : MonoBehaviour {

    public string[] objectsToCheckForByTag;

    public Lerpable targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerEnter(Collider collider)
    {

        targetObject.stop();

        foreach (string s in objectsToCheckForByTag)
        {
            if (collider.transform.gameObject.tag.Equals(s))
            {
                targetObject.landed = true;
            }
        }

        
    }
}
