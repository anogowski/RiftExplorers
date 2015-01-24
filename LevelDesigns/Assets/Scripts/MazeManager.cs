using UnityEngine;
using System.Collections;

public class MazeManager : GameManager {

    AudioSource water;
	// Use this for initialization
	void Start () 
    {
        water = AudioManager.Instance.PlaySounds(Sounds.Water, SoundActions.Loop, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            AudioManager.Instance.PlaySounds(Sounds.Hallelujah, SoundActions.Play, Vector3.zero);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.Instance.StopSound(water);
        }
	}
}
