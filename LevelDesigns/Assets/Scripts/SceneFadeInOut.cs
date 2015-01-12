using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

    public GameObject playerPrefab;

    public static bool fadingIn = false;
    public static bool sceneFade = false;

    private float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start () {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        if (sceneFade)
            FadeOutScene();
	}

    void FadeToClear()
    {
        Debug.Log("Hello");
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    void FadeToBlack()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    //rework to fade in better
    void BringToLife()
    {
        fadingIn = true;
        while (guiTexture.color.a > 0.05f)
        {
            FadeToClear();
        }
        if (guiTexture.color.a <= 0.05f)
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;

            sceneFade = false;
            fadingIn = false;
        }
    }

    public void FadeOutScene()
    {
        fadingIn = false;
        guiTexture.enabled = true;

        FadeToBlack();

        if(guiTexture.color.a >= .95f)
        {
            GameObject obj = GameObject.Find("WaterRoom");
            Destroy(obj);
            playerPrefab.transform.position = new Vector3(5.25f, 3.5f, -0.8f);
            BringToLife();
        }
    }
}
