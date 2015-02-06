using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    private GameObject wave;
    private Transform waveHeight;
    private GameObject player;
    private Vector3 playerHeight;
    public GameObject plane;

    private int count = 0;

    private bool played = false;
    private bool isBeingHurt = false;
    public static bool dead = false;

    public float TIME;
    private float elapsedTime = 0f;

    void Start()
    {
        wave = GameObject.FindGameObjectWithTag("Water");
        waveHeight = wave.transform.FindChild("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FadingManager.fadingOut)
        {
            findHeight();
            //Debug.Log("Player height: " + playerHeight.y + "Water height: " + waveHeight.transform.position.y);
            if (playerHeight.y - 0.75f <= waveHeight.transform.position.y)
            {
                playerHurt();
            }
            else
            {
                isBeingHurt = false;
            }

            if (isBeingHurt)
            {
                plane.SetActive(true);
                elapsedTime += Time.deltaTime;
                if (elapsedTime > TIME)
                {
                    elapsedTime = 0f;
                    played = false;
                    plane.SetActive(false);
                    count++;
                    Debug.Log("played" + played);
                    if (count >= 5)
                    {
                        dead = true;
                        count = 0;
                    }
                }
            }
            else
            {
                plane.SetActive(false);
            }
        }
        else
        {
            plane.SetActive(false);
        }
    }

    private void findHeight()
    {
        wave = GameObject.FindGameObjectWithTag("Water");
        waveHeight = wave.transform.FindChild("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position;
    }

    private void playerHurt()
    {
        if(!played)
        {
            played = true;
            isBeingHurt = true;
            AudioManager.Instance.PlaySounds(Sounds.Player_Hurt, SoundActions.Play, plane.transform.position);
        }
        if (!isBeingHurt)
            isBeingHurt = true;
    }
}
