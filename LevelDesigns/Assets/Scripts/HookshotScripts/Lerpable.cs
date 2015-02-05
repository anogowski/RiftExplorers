using UnityEngine;
using System.Collections;

public class Lerpable : MonoBehaviour {

    public bool autoStart;

    private bool lerping;

    private Vector3 startPosition;
    private Vector3 currentPosition;

    public float speed;
    public float limit;

    float startTime;
    float fullLength;

    /**/
	// Use this for initialization
	void Start () {
        if (autoStart)
        {
            lerping = true;
        }
	}
	/**/
      
	// Update is called once per frame
	void Update () 
    {
        if (lerping)
        {
            bool move = withInRange(this.transform.position, startPosition);
            if (move)
            {
                lerp();
            }
            else
            {
                stop();
            }
            
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        stop();
    }

    private void stop()
    {
        lerping = false;
    }

    private void lerp()
    {
        this.gameObject.transform.Translate(this.gameObject.transform.forward * Time.deltaTime * speed);
    }

    private Vector3 getForward()
    {
        return Vector3.zero;
    }

    public void startLerp()
    {
        lerping = true;
        this.gameObject.transform.parent = null;
        startPosition = this.gameObject.transform.position;

    }

    private Vector3 getTargetPosition(Vector3 position, Vector3 forward)
    {
        Vector3 targetPoint = Vector3.zero;
        RaycastHit hit;
        Ray ray = new Ray(position, forward);
        if (Physics.Raycast(ray, out hit))
        {
            
        }
        return targetPoint;
    }

    private bool withInRange(Vector3 hitPosition, Vector3 startPosition)
    {
        return ((hitPosition - startPosition).magnitude < limit);
    }

    private Vector3 lerp(float startime, float legnth, float speed, Vector3 start, Vector3 end)
    {
        float distCovered = ((Time.time - startime) * speed);
        float percentOfJourney = distCovered / legnth;
        //Debug.Log("distCovered: " + distCovered);
        //Debug.Log("percentOfJourney: " + percentOfJourney);
        return Vector3.Lerp(start, end, percentOfJourney);
    }
}
