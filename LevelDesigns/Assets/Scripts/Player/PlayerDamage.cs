using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    GameObject wave;
    Transform waveHeight;
    GameObject player;
    Vector3 playerHeight;
    public GameObject plane;
    bool played = false;
    public static bool dead = false;
    int count = 0;

    void Start()
    {
        wave = GameObject.FindGameObjectWithTag("Water");
        waveHeight = wave.transform.FindChild("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position;
    }


    IEnumerator playerHurt()
    {
        if (!played)
        {
            played = true;
            plane.SetActive(true);
            AudioManager.Instance.PlaySounds(Sounds.Player_Hurt, SoundActions.Play, plane.transform.position);
        }
        yield return new WaitForSeconds(2f);
        played = false;
        plane.SetActive(false);
        count++;
        if (count >= 5)
        {
            dead = true;
            count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        findHeight();
        if (playerHeight.y < waveHeight.position.y )
        {
            playerHurt();
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
