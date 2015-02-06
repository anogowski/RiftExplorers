using UnityEngine;
using System.Collections;
using EventSystem;

public class WaterTempleManager : Singleton<WaterTempleManager>, EventSystem.EventListener
{
    public int attempts = 1;
    public int currentTime;
    public int compeletionTime;
    public int bestTime = 3600;

    Counter counter = new Counter();
    AudioSource chainSound;
    public AudioSource water;
    EventSender eventSender = new EventSender();
    public bool playerAlive = true;

    public float distanceOut;
    GameObject player;
    OVRInterface playerControl;
    GUIv1 playerGUI;
    private bool waterActive;

    private Vector3 originalPlayerPos;

    public GameObject baseWave;
    private bool startedCoroutine;
    // Use this for initialization

    void Awake()
    {
        eventSender.Subscribe(this);
        eventSender.Subscribe(counter);
        eventSender.SendEvent(EventSystem.EventType.Level_Start);
        eventSender.SendEvent(EventSystem.EventType.Player_Alive);
        Screen.lockCursor = true;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        originalPlayerPos = player.transform.position;
        playerControl = player.GetComponent<OVRInterface>();
        playerGUI = GameObject.FindGameObjectWithTag("UI").GetComponent<GUIv1>();
        waterActive = false;
        startedCoroutine = false;
        string state = PlayerPrefs.GetString("GameState", "Start");
        if (state.Equals("Playing"))
        {
            attempts = PlayerPrefs.GetInt("CurrentAttempts", attempts);
            currentTime = PlayerPrefs.GetInt("CurrentTime", currentTime);
        }

    }

    void EventListener.React(EventSystem.EventType eventType)
    {
        switch (eventType)
        {
            case EventSystem.EventType.Level_Start:
                AudioManager.Instance.PlaySounds(Sounds.WaterTempleTheme, SoundActions.Loop, Vector3.zero, 0.1f);
                bestTime = PlayerPrefs.GetInt("bestTimeWaterTemple", 3600);
                break;
            case EventSystem.EventType.Player_Alive:
                break;
            case EventSystem.EventType.Get_Item:
                AudioManager.Instance.PlaySounds(Sounds.GetItem, SoundActions.Play, player.transform.position, 0.25f);
                playerGUI.setCrossHairVisable(true);
                WaterFountain.Triggered = true;
                break;
            case EventSystem.EventType.Player_Death:
                AudioManager.Instance.PlaySounds(Sounds.WaterTempleDeath, SoundActions.Play, Vector3.zero, 1.0f);
                attempts++;
                break;
            case EventSystem.EventType.Checkpoint:
                break;
            case EventSystem.EventType.Turn_Valve:
                if (!Appear.Triggered)
                {
                    Appear.Triggered = true;
                    AudioManager.Instance.PlaySounds(Sounds.Valve, SoundActions.Play, player.transform.position, 0.25f);
                }
                break;
            case EventSystem.EventType.Valve_Open:
                Appear.Triggered = false;
                break;
            case EventSystem.EventType.Valve_Closed:
                        AudioManager.Instance.StopSound(water);
                        AudioManager.Instance.PlaySounds(Sounds.Waves, SoundActions.Loop, new Vector3(0f, 10f, 0f), 0.5f);
                break;
            case EventSystem.EventType.Level_Complete:
                {
                    //AudioManager.Instance.PlaySounds(Sounds.WaterTempleComplete, SoundActions.Play, player.transform.position);
                    compeletionTime = currentTime;
                    if (compeletionTime < bestTime)
                    {
                        bestTime = compeletionTime;
                        PlayerPrefs.SetInt("bestTimeWaterTemple", bestTime);
                    }
                   int bestAttempts = PlayerPrefs.GetInt("bestAttemptsWaterTemple", 100);
                    if (attempts <= bestAttempts)
                    {
                        PlayerPrefs.SetInt("bestAttemptsWaterTemple", attempts);
                    }
                    //use to reset best values
                    //PlayerPrefs.SetInt("bestTimeWaterTemple", 3600);
                    //PlayerPrefs.SetInt("bestAttemptsWaterTemple", 100);
                    PlayerPrefs.Save();
                    string[] lines = { "PlayerData", "Best Time: " + PlayerPrefs.GetInt("bestTime", 3600) + "", "Best Attempts: ", PlayerPrefs.GetInt("bestAttempts", 100) + "" };
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
        //Debug.Log("Player height: " + player.transform.position.y);
       counter.Update();
       currentTime = counter.currentTime;
        //Debug.Log(counter.currentTime);
        if (ActionInput.Instance.checkAction(ActionInput.ActionsToTrack.Interact))
        {
            Vector3 forward = playerControl.getForward();
            Vector3 position = playerControl.getPosition();
            //Debug.Log("Interaction called");
            interact(forward, position);
        }

        Transform hookShot = GameObject.FindGameObjectWithTag("Left_Hand").transform.FindChild("HookShot");

        if ((hookShot != null) && !waterActive)
        {
          activateWater();  
        }

        bool val = playerControl.getFallDeath();
        checkFallHeight(val);

        if(waterActive)
        {
            checkForDeath();
            checkForComplete();
        }
    }

    private void interact(Vector3 forward, Vector3 position)
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

    private void activateWater()
    {
       waterActive = true;
       water = AudioManager.Instance.PlaySounds(Sounds.Water, SoundActions.Loop, Vector3.zero);
       //Debug.Log("Activating water");

       GameObject wave = GameObject.FindGameObjectWithTag("Water");
       Transform wave1 = wave.transform.FindChild("Wave");
       Transform wave2 = wave.transform.FindChild("Water2");

       wave1.GetComponent<WaterSimple>().enabled = true;
       wave1.GetComponent<WaterBehavior>().enabled = true;

       wave2.GetComponent<Fliparino>().enabled = true;
       wave2.GetComponent<WaterBehavior>().enabled = true;

       activateBaseWater();

    }

    private void activateBaseWater()
    {
        GameObject wave = GameObject.FindGameObjectWithTag("Water");
        Transform wave1 = wave.transform.FindChild("Wave");
        Transform wave2 = wave.transform.FindChild("Water2");

        if(wave1.transform.position.y > -53.25f)
        {
            baseWave.SetActive(true);
        }
    }

    private void checkFallHeight(bool val)
    {
        if (val && !startedCoroutine)
        {
            StartCoroutine(myMethod());
        }
    }

    private void checkForDeath()
    {
        GameObject wave = GameObject.FindGameObjectWithTag("Water");
        Transform wave1 = wave.transform.FindChild("Wave");
        Transform wave2 = wave.transform.FindChild("Water2");

        if (player.transform.position.y + 0.545f <= wave1.transform.position.y && !startedCoroutine && PlayerDamage.dead)
        {
            StartCoroutine(myMethod());
            
            /**
            //die();
            //player.transform.position = originalPlayerPos;
            //wave1.transform.position = new Vector3(wave1.transform.position.x, -55.22f, wave1.transform.position.z);
            //wave2.transform.position = new Vector3(wave2.transform.position.x, -150.5f, wave2.transform.position.z);
            //baseWave.SetActive(false);
            //Appear.Triggered = false;
            ////Debug.Log("Counter: " + attempts);
            ////have fade out here
            //eventSender.SendEvent(EventSystem.EventType.Player_Alive);
             /* */
        }
    }

    private void checkForComplete()
    {
        if(CompletedLevelScript.completed)
        {
            eventSender.SendEvent(EventSystem.EventType.Level_Complete);
        }
    }

    IEnumerator myMethod()
    {
        //Debug.Log("You're dead");
        startedCoroutine = true;
        FadingManager.fadingOut = true;
        eventSender.SendEvent(EventSystem.EventType.Player_Death);
        yield return new WaitForSeconds(2.5f);
        saveCurrent();

        //Debug.Log("I waited");
        GameObject wave = GameObject.FindGameObjectWithTag("Water");
        Transform wave1 = wave.transform.FindChild("Wave");
        Transform wave2 = wave.transform.FindChild("Water2");
        player.transform.position = originalPlayerPos;
        //Debug.Log("Player pos: " + player.transform.position);
        //Debug.Log("Origin pos: " + originalPlayerPos);
        if (baseWave.activeInHierarchy)
        {
            wave1.transform.position = new Vector3(wave1.transform.position.x, -55.2f, wave1.transform.position.z);
            wave2.transform.position = new Vector3(wave2.transform.position.x, -150.5f, wave2.transform.position.z);
            baseWave.SetActive(false);
        }
        Appear.Triggered = false;

        //Debug.Log("Counter: " + attempts);          

        //live();
        eventSender.SendEvent(EventSystem.EventType.Player_Alive);
        startedCoroutine = false;
    }
    private void saveCurrent()
    {
        PlayerPrefs.SetString("GameState", "Playing");
        PlayerPrefs.SetInt("CurrentTime", currentTime);
        PlayerPrefs.SetInt("CurrentAttempts", attempts);
        Application.LoadLevel(0);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("GameState", "Start");
        PlayerPrefs.SetInt("CurrentTime", 3600);
        PlayerPrefs.SetInt("CurrentAttempts", 0);
    }
}
