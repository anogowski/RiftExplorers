using UnityEngine;
using System.Collections;

public class FadingManager : MonoBehaviour {

    public GameObject planePrefab;
    public GameObject player;
    private float speed = 1f;
    public static bool fadingIn = false;
    public static bool fadingOut = false;
    public Camera cameraFacing;

    public void Start()
    {
        fadingIn = true;
        planePrefab.SetActive(true);
        //player.GetComponent<OVRPlayerController>().enabled = false;
        //Debug.Log("Stop for load");
    }
    public void Update()
    {
        //Debug.Log("Alpha: " + planePrefab.renderer.material.color.a);
        if((fadingOut) && planePrefab.renderer.material.color.a <= 1f)
        {
            FadeOutScene();
        }
        if (fadingIn && planePrefab.renderer.material.color.a >= 0f)
        {
            FadeInScene();
        }
    }

    void FadeToClear()
    {
        //Debug.Log("Fading to clear" + planePrefab.renderer.material.color.a);
        planePrefab.renderer.material.color = 
            Color.Lerp(planePrefab.renderer.material.color, Color.clear, speed * Time.deltaTime);
    }
    void FadeToBlack()
    {
        //Debug.Log("Fading to black" + planePrefab.renderer.material.color.a);
        planePrefab.renderer.material.color =
            Color.Lerp(planePrefab.renderer.material.color, Color.black, speed * Time.deltaTime);
    }

    public void FadeInScene()
    {
        transform.position = cameraFacing.transform.position + cameraFacing.transform.rotation * Vector3.forward * 0.1f;
        transform.LookAt(cameraFacing.transform.position);
        transform.Rotate(0f, 180f, 0f);
        FadeToClear();
        //if (planePrefab.renderer.material.color.a < .25f)
        //{
        //    player.GetComponent<OVRPlayerController>().enabled = true;
        //}
        if(planePrefab.renderer.material.color.a < 0.06f)
        {
            Color c = planePrefab.renderer.material.color;
            planePrefab.renderer.material.color = new Color(c.r, c.g, c.b, 0.05f);
        }
        if(planePrefab.renderer.material.color.a <= 0.05f)
        {
            //Debug.Log("GO");
            planePrefab.renderer.material.color = Color.clear;
            fadingIn = false;
            planePrefab.SetActive(false);
        }
    }

    public void FadeOutScene()
    {
        if (!planePrefab.activeInHierarchy)
        {
            planePrefab.SetActive(true);
            planePrefab.renderer.material.color = Color.clear;
            player.GetComponent<OVRPlayerController>().enabled = false;
            //Debug.Log("Stop for exit");
        }

        FadeToBlack();

        if(planePrefab.renderer.material.color.a >= 0.95f)
        {
            fadingOut = false;
            fadingIn = true;
        }
    }
}
