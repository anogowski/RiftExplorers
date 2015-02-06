using UnityEngine;
using System.Collections;

public class WaterFountain : MonoBehaviour {

    public ParticleSystem p;
    public static bool Triggered = false;
    void Start()
    {
        p.Stop();
    }
	private void Play () 
    {
        p.playbackSpeed = 1;
        p.Play();
	}

    void Update()
    {
        if (Triggered)
        {
            Play();
        }
        else
        {
            p.Stop();
        }
    }
}
