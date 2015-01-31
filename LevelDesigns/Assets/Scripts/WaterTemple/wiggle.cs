using UnityEngine;
using System.Collections;

public class wiggle : MonoBehaviour {

    public Quaternion minRotation;
    public Quaternion maxRotation;

    public float percentChance;

    enum PlatformStates
    {
        Still,
        Wiggle,
        Fall
    };

    //Move
    public AnimationCurve curve;
    public Vector3 distance;
    public float speed;

    private Vector3 startPos, toPos;
    private float timeStart;
    //

    private float min;
    private float max;

    private bool shouldWiggle;
    private bool fall;

    PlatformStates platformState;

	// Use this for initialization
	void Start () 
    {
        min = 1;
        max = 100;

        if (percentChance < min)
        {
            percentChance = max;
        }
        else if (percentChance > max)
        {
            percentChance = max;
        }

        //Move
        startPos = transform.position;
        randomToPos();
        //
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(platformState == PlatformStates.Wiggle)
        {
            wiggleTime();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Platform hit");
        bool takeAction = calculateIfAction(min, max);

        if (takeAction)
        {
            platformState = PlatformStates.Wiggle;
        }
    }


    private bool calculateIfAction(float min, float max)
    {
        bool action = false;

        float results = Random.Range(min, max);

        if (results < percentChance)
        {
            action = true;
        }

        return action;
    }

    //Move
    void randomToPos()
    {
        toPos = startPos;
        toPos.x += Random.Range(-1.0f, +1.0f) * distance.x;
        toPos.y += Random.Range(-1.0f, +1.0f) * distance.y;
        toPos.z += Random.Range(-1.0f, +1.0f) * distance.z;
        timeStart = Time.time;
    }

    private void wiggleTime()
    {
        float d = (Time.time - timeStart) / speed, m = curve.Evaluate(d);
        if (d > 1)
        {
            randomToPos();
        }
        else if (d < 0.5)
        {
            transform.position = Vector3.Lerp(startPos, toPos, m * 2.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(toPos, startPos, (m - 0.5f) * 2.0f);
        }
    }
    //
}
