using UnityEngine;
using System.Collections;

public class SpikesTriggerScript : MonoBehaviour {

    public GameObject prefab;
    private float delay = -1;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if(delay > -1)
        {
            delay += Time.deltaTime;
        }
        if(delay >= 0.25f)
        {
            prefab.transform.position = new Vector3(prefab.transform.position.x, 0f, prefab.transform.position.z);
        }
        if(delay > 3f)
        {
            delay = -1f;
            prefab.transform.position = new Vector3(prefab.transform.position.x, -2f, prefab.transform.position.z);
        }
    }
	
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer"))
        {
            delay = 0f;
        }
    }
}
