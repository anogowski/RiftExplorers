using UnityEngine;
using System.Collections;

public class HookShot : MonoBehaviour, IInteractable
{

    public bool lerping;

    public float speed;

    public float offSet;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float startTime;
    private float fullLength;

    private OVRInterface user;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lerping)
        {
            Vector3 newPosition = lerp(startTime, fullLength, speed, startPosition, targetPosition);
            user.transform.position = newPosition;
            float gap = Vector3.Magnitude(newPosition - targetPosition);
            if (gap <= offSet)
            {
                lerping = false;
                targetPosition = Vector3.zero;
            }
        }
        else
        {
            if (!lerping && Input.GetMouseButtonDown(0) && user != null)
            {
                startTime = Time.time;
                startPosition = user.transform.position;
                OVRInterface ovrInt = user.GetComponent<OVRInterface>();
                targetPosition = getTargetPosition(user.transform.position, ovrInt.getForward());
                if (targetPosition != Vector3.zero)
                {
                    lerping = true;
                    fullLength = Vector3.Magnitude(startPosition - targetPosition);
                }
                else
                {
                    Debug.Log("No Hook-Loop found");
                }
            }

        }
	}

    private Vector3 getTargetPosition(Vector3 position, Vector3 forward)
    {
        Vector3 targetPoint = Vector3.zero;
        RaycastHit hit;
        Ray ray = new Ray(position, forward);
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag.Equals("HookLoop"))
            {
                targetPoint = hit.transform.position;
                Debug.Log("Hook-Loop found");
            }
        }

        return targetPoint;
    }

    private Vector3 lerp(float startime, float legnth, float speed, Vector3 start, Vector3 end)
    {
        float distCovered = ((Time.time - startime) * speed);
        float percentOfJourney = distCovered / legnth;
        Debug.Log("distCovered: " + distCovered);
        Debug.Log("percentOfJourney: " + percentOfJourney);
        return Vector3.Lerp(start, end, percentOfJourney);
    }

    //The player who is holding the HookShot
    public void interact(GameObject user)
    {
        //Debug.Log("Hook interact with hook shot");
        if (user.tag.Equals("Player"))
        {

            disableColition();
            this.user = (OVRInterface) GameObject.FindGameObjectWithTag("Player").GetComponent<OVRInterface>();
            this.user.pickUP(Hand.Left, this.gameObject);
            
        }

    }

    private void pickup(Transform hand)
    {
        this.transform.parent = hand;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
    }

    private void disableColition()
    {
        (this.transform.GetComponent<CapsuleCollider>() as CapsuleCollider).enabled = false;
    }
}
