using UnityEngine;
using System.Collections;

public class ChainLink : MonoBehaviour {

    private bool isVisable;
    private MeshRenderer meshRender;
    private GameObject marker;
    private Direction direction;

    public float lowerLimit;
    public float upperLimit;

	// Use this for initialization
	void Start () {
        meshRender = this.GetComponent<MeshRenderer>() as MeshRenderer;
        marker = GameObject.FindGameObjectWithTag("Muzzel");
        isVisable = false;
        meshRender.enabled = isVisable;
        direction = Direction.Forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkPositoning();
	}

    public Direction getDirecdtion()
    {
        return direction;
    }

    public void reverse()
    {
        if (direction.Equals(Direction.Forward))
        {
            direction = Direction.Backward;
        }
        else if (direction.Equals(Direction.Backward))
        {
            direction = Direction.Forward;
        }
    }

    private void checkPositoning()
    {
        Vector3 linkPosition = this.transform.position;
        Vector3 markerPosition = marker.transform.position;
        float magnitude = Vector3.Magnitude(markerPosition - linkPosition);
        if (magnitude <= upperLimit && magnitude >= lowerLimit)
        {
            checkDirection();
        }
    }

    private void checkDirection()
    {
        if (direction.Equals(Direction.Forward) && !isVisable)
        {
            switchVisablity();
        }
        else if (direction.Equals(Direction.Backward) && isVisable)
        {
            switchVisablity();
        }
    }

    private void switchVisablity()
    {
        if (isVisable)
        {
            isVisable = false;
            meshRender.enabled = isVisable;
        }
        else
        {
            isVisable = true;
            meshRender.enabled = isVisable;
        }
    }


    public bool getIsVisable()
    {
        return isVisable;
    }
}
