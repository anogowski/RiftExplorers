using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerDamage : MonoBehaviour
{
    private GameObject wave;
    private Transform waveHeight;
    private GameObject player;
    private Vector3 playerHeight;
    public GameObject plane;

    private int count = 0;

    private bool played = false;
    public static bool dead = false;
    
    private Stopwatch stopwatch = new Stopwatch();

    private const float TIME = 500f;
    void Start()
    {
        wave = GameObject.FindGameObjectWithTag("Water");
        waveHeight = wave.transform.FindChild("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position;
    }


    private void playerHurt()
    {
        if (!played)
        {
            played = true;
            plane.SetActive(true);
            AudioManager.Instance.PlaySounds(Sounds.Player_Hurt, SoundActions.Play, plane.transform.position);
            stopwatch.Start();
        }
        if (stopwatch.Elapsed.TotalMilliseconds > TIME)
        {
            played = false;
            plane.SetActive(false);
            count++;
            if (count >= 5)
            {
                dead = true;
                count = 0;
            }
            stopwatch.Reset();
        }
    }

    // Update is called once per frame
    void Update()
    {
        findHeight();
        //Debug.Log("Player: " + playerHeight.y);
        //Debug.Log("Wave: " + waveHeight.position.y);
        //UnityEngine.Debug.Log("Time:" + stopwatch.Elapsed.TotalMilliseconds);
        if (playerHeight.y <= waveHeight.position.y && stopwatch.Elapsed.TotalMilliseconds <= TIME)
        {
            playerHurt();
        }
        else
        {
            plane.SetActive(false);
        }
        if(stopwatch.Elapsed.TotalMilliseconds > TIME)
        {
            stopwatch.Reset();
        }
    }

    void findHeight()
    {
        wave = GameObject.FindGameObjectWithTag("Water");
        waveHeight = wave.transform.FindChild("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position;
    }
}
