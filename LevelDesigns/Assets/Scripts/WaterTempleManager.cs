using UnityEngine;
using System.Collections;

public class WaterTempleManager : MonoBehaviour
{

    public float distanceOut;
    GameObject player;
    OVRInterface playerControl;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<OVRInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 forward = playerControl.getForward();
            Vector3 position = player.transform.position;
            Debug.Log("Interaction called");
            interacte(forward, position);
        }
    }

    private void interacte(Vector3 forward, Vector3 position)
    {
        forward = forward * distanceOut;
        Ray ray = new Ray(position, forward);
        RaycastHit hit;
        //I dont like this.... but i can't find a better way :(
        if (Physics.Raycast(ray, out hit))
        {
            MonoBehaviour[] mbs = hit.transform.gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour m in mbs)
            {
                if (m is IInteractable)
                {
                    IInteractable interactable = (IInteractable)m;
                    interactable.interact(player);
                    //Debug.Log("Found interactable Object");
                }
            }
        }
        else
        {
            //Debug.Log("No interactable Object was hit");
        }
    }
}
