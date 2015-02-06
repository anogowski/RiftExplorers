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


    private GameObject   userGO;
    private OVRInterface userOVRI;
    private Lerpable     userLerp;

    private GameObject hook;
    private Lerpable hookLerp;

    EventSender eventSender = new EventSender();

	// Use this for initialization
	void Start ()
    {
        eventSender.Subscribe(WaterTempleManager.Instance);
        hook = GameObject.FindGameObjectWithTag("Hook");
        hookLerp = hook.GetComponent<Lerpable>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.Fire))
        {
            if (!hookLerp.lerping && !hookLerp.landed)
            {
                hookLerp.startLerp(LerpType.Forward, Vector3.zero);
                userOVRI.lockDown(true);
            }
            else if (hookLerp.lerping)
            {
                hookLerp.stop();
            }
        }

        if (userGO != null)
        {
            if (hookLerp.landed && !userLerp.lerping)
            {
                userLerp.startLerp(LerpType.PointToPoint, hook.transform.position);
            }
            else if(!userLerp.lerping && userLerp.landed)
            {
                hookLerp.reset();
                userOVRI.lockDown(false);
            }
        }


	}

 
    //The player who is holding the HookShot
    public void interact(GameObject user)
    {
        //Debug.Log("Hook interact with hook shot");
        if (user.tag.Equals("Player"))
        {

            disableCoalition();
            this.userGO = user;
            this.userOVRI = userGO.GetComponent<OVRInterface>();
            this.userLerp = userGO.GetComponent<Lerpable>();
            this.userOVRI.pickUP(Hand.Left, this.gameObject);
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
