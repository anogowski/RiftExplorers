using UnityEngine;
using System.Collections;

public class MazeManager : GameManager {

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            AudioManager.Instance.PlaySounds(Sounds.Hallelujah, SoundActions.Play, Vector3.zero);
        }
	}
}
