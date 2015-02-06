using UnityEngine;
using System.Collections;

public class Lerpable : MonoBehaviour 
{

    public bool autoStart;
    public bool landed;
    public bool lerping;

    public float speed;
    public float limit;

    private LerpType lerpType;

    private Vector3 startPosition;
    private Vector3 currentPosition;
    private Vector3 endPosition;

    private Transform parent;

    private float startTime;
    private float length;

    private float fullLength;

    /**/
	// Use this for initialization
	void Start () {
        if (autoStart)
        {
            startLerp(LerpType.Forward, Vector3.zero);
            //lerping = true;
        }
	}
	/**/
      
	// Update is called once per frame
	void Update () 
    {

        if (lerping & !landed)
        {
            if (lerpType == LerpType.Forward)
            {
                bool move = withInRange(this.transform.position, startPosition, limit);
                if (move)
                {
                    lerp();
                }
                else
                {
                    stop();
                }
            }
            else if (lerpType == LerpType.PointToPoint)
            {
                pointLerp();
            }
        }
        
	}

    private void deParent()
    {
        parent = this.gameObject.transform.parent;
        this.gameObject.transform.parent = null;
    }

    private void reparent()
    {
        if (parent != null)
        {
            this.gameObject.transform.parent = parent;
        }
    }

    public void startLerp(LerpType type, Vector3 endPoint)
    {
        lerping = true;
        landed = false;
        lerpType = type;
        endPosition = endPoint;
        startTime = Time.time;
        deParent();
        startPosition = this.gameObject.transform.position;
        length = Vector3.Magnitude(startPosition - endPoint);
    }

    private void lerp()
    {
        Vector3 forward = this.gameObject.transform.forward;
        this.gameObject.transform.Translate((this.gameObject.transform.forward) * (Time.deltaTime * speed));
        Debug.Log("Forward vec3: " + forward);
    }

    private void pointLerp()
    {
        this.gameObject.transform.position = lerp(startTime, length, speed, startPosition, endPosition);
        if(withInRange(this.gameObject.transform.position, endPosition, limit))
        {
            stop();
            reset();
        }
    }

    private Vector3 lerp(float startTime, float legnth, float speed, Vector3 start, Vector3 end)
    {
        float distCovered = ((Time.time - startTime) * speed);
        float percentOfJourney = distCovered / legnth;
        //Debug.Log("distCovered: " + distCovered);
        //Debug.Log("percentOfJourney: " + percentOfJourney);
        return Vector3.Lerp(start, end, percentOfJourney);
    }

    private bool withInRange(Vector3 current, Vector3 end, float limit)
    {
        return ((current - end).magnitude < limit);
    }

    public void stop()
    {
        lerping = false;

    }

    public void reset()
    {
        //this.gameObject.transform.parent = parent;
        reparent();
        this.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.localRotation = Quaternion.identity;
    }

    private Vector3 getForward()
    {
        return this.transform.forward;
    }

    
}