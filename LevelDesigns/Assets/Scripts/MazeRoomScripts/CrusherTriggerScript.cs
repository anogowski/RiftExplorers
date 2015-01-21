using UnityEngine;
using System.Collections;

public class CrusherTriggerScript : MonoBehaviour {

    public GameObject prefab;

    void Start()
    {
        //prefab.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player") || other.gameObject.name.Equals("OVRPlayer"))
        {
            //prefab.SetActive(true);
            Rigidbody r = prefab.AddComponent<Rigidbody>();
            r.constraints = RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
            r.velocity = new Vector3(0f, -10f, 0f);
        }
    }
}
