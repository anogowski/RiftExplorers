using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : Singleton<AudioManager>
{
    static List<AudioClip> clips = new List<AudioClip>();
  
    private void LoadSounds()
    {
        clips.Add((AudioClip)Resources.Load("Hallelujah", typeof(AudioClip)));
        clips.Add((AudioClip)Resources.Load("rushing_water", typeof(AudioClip)));

    }

    public AudioSource PlaySounds(Sounds sound, SoundActions action, Vector3 position)
    {
        AudioClip clip = new AudioClip();
        AudioSource source =  new AudioSource();
        switch (sound)
        {
            case Sounds.Hallelujah:
                clip = clips.Find(n => n.name.Equals("Hallelujah"));
                break;
            case Sounds.Water:
                clip = clips.Find(n => n.name.Equals("rushing_water"));
                break;
            case Sounds.JamieScream:
                break;
            default:
                break;
        }

        switch (action)
        {
            case SoundActions.Play:
                source = Play(clip, position);
                break;
            case SoundActions.Play_Emitter:
                break;
            case SoundActions.Loop:
                source = PlayLoop(clip, Vector3.zero);
                break;
            case SoundActions.Loop_Emitter:
                break;
            case SoundActions.Fade:
                break;
            case SoundActions.VoiceOver:
                break;
            default:
                break;
        }
        return source;
    }
    
    
    
    class ClipInfo
    {
        public AudioSource source { get; set; }
        public float defaultVolume { get; set; }
    }

    private List<ClipInfo> activeAudio;

    //On start of the level the Audio Manager attaches itself to the Level Manager
    void Awake()
    {
        activeAudio = new List<ClipInfo>();
        Debug.Log("Initializing Audio Manager");
        try
        {
            transform.parent = GameObject.FindGameObjectWithTag("LevelManager").transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
        catch
        {
            Debug.Log("Unable to find Level Manager");
        }

        Debug.Log("Loading Sounds");
        try
        {
            LoadSounds();
        }
        catch
        {
            Debug.Log("ERROR: Loading Sounds");
        }
    }

    void Update()
    {
        updateActiveAudio();
    }

    public AudioSource Play(AudioClip clip, Transform emitter, float volume = 0.5f)
    {
        var source = Play(clip, emitter.position, volume);
        source.transform.parent = emitter;
        return source;
    }

    public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume = 0.5f)
    {
        if (soundOrigin ==null)
        {
            soundOrigin = Vector3.zero;
        }
        // Create empty game object with the name of the audio clip
        GameObject soundLocation = new GameObject("Audio: " + clip.name);
        soundLocation.transform.position = soundOrigin;

        // Create Source
        AudioSource source = soundLocation.AddComponent<AudioSource>();
        SetSource(ref source, clip, volume);
        source.Play();
        Destroy(soundLocation, clip.length);

        // Set source active
        activeAudio.Add(new ClipInfo{source= source, defaultVolume = volume});
        return source;
    }

    public AudioSource PlayLoop(AudioClip loop, Vector3 soundOrigin, float volume = 0.5f)
    {
        GameObject soundLocation = new GameObject("Audio: " + loop.name);
        soundLocation.transform.position = soundOrigin;
        return Loop(soundLocation,loop, volume);
    }

    public AudioSource PlayLoop(AudioClip loop, Transform emitter, float volume = 0.5f)
    {
        // Create empty game object with the name of the audio clip
        GameObject movingSoundLoc = new GameObject("Audio: " + loop.name);
        movingSoundLoc.transform.position = emitter.position;
        movingSoundLoc.transform.parent = emitter;

       return Loop(movingSoundLoc, loop, volume);
       
    }

    private AudioSource Loop(GameObject soundLocation, AudioClip clip, float volume = 0.5f)
    {
        //Create Source
        AudioSource source = soundLocation.AddComponent<AudioSource>();
        SetSource(ref source, clip, volume);
        source.loop = true;
        source.Play();

        // Set source active
        activeAudio.Add(new ClipInfo { source = source, defaultVolume = volume });
        return source;
    }

    public void StopSound(AudioSource toStop)
    {
        try
        {
            Destroy(activeAudio.Find(x => x.source == toStop).source.gameObject);

        }
        catch
        {
            Debug.Log("ERROR: Could not stop " + toStop);
        }
    }

    private void SetSource(ref AudioSource source, AudioClip clip, float volume)
    {
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.dopplerLevel = 0.2f;
        source.minDistance = 150;
        source.maxDistance = 1500;
        source.clip = clip;
        source.volume = volume;
    }

    private void updateActiveAudio()
    {
        var toRemove = new List<ClipInfo>();
        try
        {
            foreach (var audioClip in activeAudio)
            {
                if (!audioClip.source)
                {
                    toRemove.Add(audioClip);
                }
            }
        }
        catch
        {
            Debug.Log("Error updating active audio clips");
            return;
        }
        //cleanup audio
        foreach (var audioClip in toRemove)
        {
            activeAudio.Remove(audioClip);
        }
    }

}
