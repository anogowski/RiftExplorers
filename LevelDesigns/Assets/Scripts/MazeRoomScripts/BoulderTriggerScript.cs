using UnityEngine;
using System.Collections;

public class BoulderTriggerScript : MonoBehaviour {

    public GameObject prefab;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer"))
        {
            //prefab.SetActive(true);
            Rigidbody r = prefab.GetComponent<Rigidbody>();
            r.velocity = new Vector3(-15f, 0f, 0f);
        }
    }
}
