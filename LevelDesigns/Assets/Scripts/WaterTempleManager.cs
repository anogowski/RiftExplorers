using UnityEngine;
using System.Collections;
using EventSystem;

public class WaterTempleManager : GameManager, EventSystem.EventListener
{
    Counter counter = new Counter();
    AudioSource chainSound;
    AudioSource water;
    EventSender eventSender = new EventSender();
    public bool playerAlive = true;


    public float distanceOut;
    GameObject player;
    OVRInterface playerControl;
    GUIv1 playerGUI;
    private bool waterActive;
    // Use this for initialization

    void Awake()
    {
        eventSender.Subscribe(this);
        eventSender.Subscribe(counter);
        eventSender.SendEvent(EventSystem.EventType.Level_Start);
        eventSender.SendEvent(EventSystem.EventType.Player_Alive);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<OVRInterface>();
        playerGUI = GameObject.FindGameObjectWithTag("UI").GetComponent<GUIv1>();
        waterActive = false;

        AudioManager.Instance.PlaySounds(Sounds.WaterTempleTheme, SoundActions.Loop, Vector3.zero);



    }

  void EventListener.React(EventSystem.EventType eventType)
    {
        switch (eventType)
        {
            case EventSystem.EventType.Level_Start:
                   bestTime = PlayerPrefs.GetInt("bestTime", 3600);
                break;
            case EventSystem.EventType.Player_Alive:
                break;
            case EventSystem.EventType.Get_Item:
                AudioManager.Instance.PlaySounds(Sounds.GetItem, SoundActions.Play, player.transform.position);
                playerGUI.setCrossHairVisable(true);
                break;
            case EventSystem.EventType.Player_Death:
                attempts++;
                break;
            case EventSystem.EventType.Checkpoint:
                break;
            case EventSystem.EventType.Level_Complete:
                {
                    compeletionTime = currentTime;
                    if (compeletionTime < bestTime)
                    {
                        bestTime = compeletionTime;
                        PlayerPrefs.SetInt("bestTime", bestTime);
                    }
                    PlayerPrefs.Save();
                    string[] lines = { "PlayerData", "Best Time: " + PlayerPrefs.GetInt("bestTime", 3600) };
                    System.IO.File.WriteAllLines(Application.persistentDataPath + "\\SaveFile.txt", lines);
                }
                break;
            case EventSystem.EventType.DoorOpen:
                break;
            case EventSystem.EventType.DoorClose:
                break;
            default:
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
       counter.Update();
       currentTime = counter.currentTime;
        //Debug.Log(counter.currentTime);
        if (ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.interact))
        {
            Vector3 forward = playerControl.getForward();
            Vector3 position = playerControl.getPosition();
            //Debug.Log("Interaction called");
            interacte(forward, position);
        }

        Transform hookShot = GameObject.FindGameObjectWithTag("Left_Hand").transform.FindChild("HookShot");

        if ((hookShot != null) && !waterActive)
        {
            waterActive = true;

            //activateWater();
        }
        
        if (!waterActive)
        {
            //AudioManager.Instance.StopSound(water);
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
                    eventSender.SendEvent(EventSystem.EventType.Get_Item);
                    //Debug.Log("Found interactable Object");
                }
            }
        }
        else
        {
            //Debug.Log("No interactable Object was hit");
        }
    }

    private void activateWater()
    {
       Debug.Log("Activating water");

       GameObject wave = GameObject.FindGameObjectWithTag("Water");
       Transform wave1 = wave.transform.FindChild("Wave");
       Transform wave2 = wave.transform.FindChild("Wave2");

       wave1.GetComponent<WaterSimple>().enabled = true;
       wave1.GetComponent<WaterBehavior>().enabled = true;

       wave2.GetComponent<Fliparino>().enabled = true;
       wave2.GetComponent<WaterBehavior>().enabled = true;

       water = AudioManager.Instance.PlaySounds(Sounds.Water, SoundActions.Loop, Vector3.zero);
    }
}
