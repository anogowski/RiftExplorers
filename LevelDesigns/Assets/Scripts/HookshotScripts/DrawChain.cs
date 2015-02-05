using UnityEngine;
using System.Collections;

public class DrawChain : MonoBehaviour {

    public GameObject gamObjOne;
    public GameObject gamObjTwo;
    public float width;
    private float dist;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () 
    {
	   lineRenderer = GetComponent<LineRenderer>();
       lineRenderer.SetPosition(0, gamObjOne.transform.position);
       lineRenderer.SetWidth(width, width);
       dist = Vector3.Distance(gamObjOne.transform.position, gamObjTwo.transform.position);
	}

    public void setTargetPoints(GameObject one, GameObject two)
    {
        gamObjOne = one;
        gamObjTwo = two;
    }
	
	// Update is called once per frame
	void Update () 
    {
        lineRenderer.SetPosition(0, gamObjTwo.transform.position);
	}
}
