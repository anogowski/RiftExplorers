using UnityEngine;
using System.Collections;

public class FloatingPlatforms : MonoBehaviour {

	public static float height = -1.0f;
    private bool Spawn = false;
    //public GameObject prefab;
	// Use this for initialization
	void Start () 
	{
		this.transform.position = new Vector3 (0.7f, height, -0.1f);
		//this.transform.position.y = height;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(WaterBehavior.waterHeight == 3.2f && Appear.Triggered)
        {
            if (height < 0f)
            {
                this.transform.position += new Vector3(0f, 0.05f, 0f);
                height += 0.05f;
            }
            if(height > 0f)
            {
                height = 0.045f;
                this.transform.position = new Vector3(0.7f, height, -0.1f);
            }
        }
        //if(!Appear.Triggered)
        //{
        //    if (this.transform.position.y < 3.2f)
        //    {
        //        this.transform.position += new Vector3 (0f, 0.001f, 0f);
        //    }
        //    else
        //    {
        //        this.transform.position = new Vector3 (0f, 3.2f, 0f);
        //    }
        //}
        //else
        //{
        //    if (this.transform.position.y < 3.2f)
        //    {
        //        this.transform.position += new Vector3(0.0f, 0.05f,0f);
        //    }
        //    else
        //    {
        //        this.transform.position = new Vector3 (0f, 3.2f, 0f);
        //    }
        //}
	}
}
