using UnityEngine;
using System.Collections;
using EventSystem;
public class HookShot : MonoBehaviour, IInteractable
{
    AudioSource chainSound;
    public bool lerping;

    public float speed;

    public float offSet;

    public float limit;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float startTime;
    private float fullLength;

    private OVRInterface user;

    private GameObject hook;

    EventSender eventSender = new EventSender();

	// Use this for initialization
	void Start ()
    {
       // eventSender.Subscribe(WaterTempleManager.Instance);
        hook = GameObject.FindGameObjectWithTag("Hook");
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private bool withInRange(Vector3 hitPosition, Vector3 startPosition)
    {
        return ((hitPosition - startPosition).magnitude < limit);
    }

    private Vector3 getTargetPosition(Vector3 position, Vector3 forward)
    {
        Vector3 targetPoint = Vector3.zero;
        RaycastHit hit;
        Ray ray = new Ray(position, forward);
        if(Physics.Raycast(ray, out hit))
        {
            
        }
        return targetPoint;
    }

    private Vector3 lerp(float startime, float legnth, float speed, Vector3 start, Vector3 end)
    {
        float distCovered = ((Time.time - startime) * speed);
        float percentOfJourney = distCovered / legnth;
        //Debug.Log("distCovered: " + distCovered);
        //Debug.Log("percentOfJourney: " + percentOfJourney);
        return Vector3.Lerp(start, end, percentOfJourney);
    }

    //The player who is holding the HookShot
    public void interact(GameObject user)
    {
        //Debug.Log("Hook interact with hook shot");
        if (user.tag.Equals("Player"))
        {

            disableCoalition();
            this.user = (OVRInterface) GameObject.FindGameObjectWithTag("Player").GetComponent<OVRInterface>();
            this.user.pickUP(Hand.Left, this.gameObject);
            eventSender.SendEvent(EventSystem.EventType.Get_Item);

        }

    }

    private void PlayChainSound()
    {
       GameObject player = GameObject.FindGameObjectWithTag("Player");
       chainSound =  AudioManager.Instance.PlaySounds(Sounds.Chain, SoundActions.Loop, player.transform.position);
    }

    private void disableCoalition()
    {
        (this.transform.GetComponent<CapsuleCollider>() as CapsuleCollider).enabled = false;
    }

    private void reset()
    {

    }
}
