using UnityEngine;
using System.Collections;

public class FloatingPlatforms : MonoBehaviour {

	public static float height = 20.3f;
    private bool Spawn = false;
    //public GameObject prefab;
	// Use this for initialization
	void Start () 
	{
        this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
		//this.transform.position.y = height;
	}
	
	// Update is called once per frame
	void Update ()
	{
        height = this.transform.position.y;
        if(!Appear.Triggered)
        {
            this.transform.position = new Vector3(this.transform.position.x, 20.3f, this.transform.position.z);
        }
        //without water
        if(Appear.Triggered)
        {
            if (height < 28.3f)
            {
                this.transform.position += new Vector3(0f, 0.05f, 0f);
                height += 0.05f;
            }
            if(height > 28.3f)
            {
                height = 28.3f;
                this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
            }
        }
        //with water
        //if (WaterBehavior.waterHeight == 10.8f && Appear.Triggered)
        //{
        //    if (height < 0.12f)
        //    {
        //        this.transform.position += new Vector3(0f, 0.05f, 0f);
        //        height += 0.05f;
        //    }
        //    if (height > 0.12f)
        //    {
        //        height = 0.12f;
        //        this.transform.position = new Vector3(0.7f, height, -0.1f);
        //    }
        //}


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
