using UnityEngine;
using System.Collections;

public class MouseLook : Singleton<MouseLook>
{

    public float sensitivity = 50f;
    public float minClamp = -90;
    public float maxClamp =  90;

    public float xRotation;
    public float yRotation;

    private Quaternion originalQuaternion;

	// Use this for initialization
	void Start () {
        //xQuaternion = new Quaternion();
        //yQuaternion = new Quaternion();
        originalQuaternion = new Quaternion();
	}
	
	// Update is called once per frame
	void Update () {

        xRotation += Input.GetAxis("Mouse X") * sensitivity;
        yRotation += Input.GetAxis("Mouse Y") * sensitivity;

        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);
        yRotation = Mathf.Clamp(yRotation, minClamp, maxClamp);

        printValues();
	}

    public void setRotation(Quaternion localRotation)
    {
        originalQuaternion = localRotation;
    }

    public Quaternion getRotation()
    {
        Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(yRotation, -Vector3.right);
        return xQuaternion;
    }

    public Quaternion getRotationY()
    {
        Quaternion yQuaternion = Quaternion.AngleAxis(-yRotation, Vector3.right);
        return yQuaternion;
    }

    public Quaternion getRotationX()
    {
        Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);
        return originalQuaternion * xQuaternion;
    }

    public Vector3 classicGetRotation()
    {
        return new Vector3(0, -yRotation, 0) * Time.deltaTime;
    }

    public Vector3 classicGetRotationX()
    {

        return new Vector3(xRotation, 0, 0) * Time.deltaTime;
    }

    public Vector3 classicGetRotationY()
    {

        return new Vector3(xRotation, -yRotation, 0) * Time.deltaTime;
    }

    private void printValues()
    {
        //Debug.Log("xRotation: " + xRotation);
        //Debug.Log("yRotation: " + yRotation);
        //Debug.Log("xQuaternion: " + xQuaternion);
        //Debug.Log("yQuaternion: " + yQuaternion);
        //Debug.Log("originalQuaternion: " + originalQuaternion);
    }

    /*
    public static float ClampAngle (float angle, float min, float max)
     {
         if (angle &lt; -360F)
             angle += 360F;
         if (angle &gt; 360F)
             angle -= 360F;
         return Mathf.Clamp (angle, min, max);
     }
     * 
     */
}
