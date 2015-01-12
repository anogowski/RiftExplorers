using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float MaxSpeed = 1f;
	private float x = 0f;
	private float y = 0f;
	private float distToGround;
	public static bool death = false;

	// Use this for initialization
	void Start () {
		distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.position.y + 0.05f < WaterBehavior.waterHeight)
		{
            Debug.Log("Death");
			death = true;
		}
		if(!death)
		{
			Movement ();
		}
        x = rigidbody.velocity.x;
        y = rigidbody.velocity.y;

	}

	void OnGUI()
	{
		GUI.Button (new Rect (5, 5, 200, 40), "CurrentSpeed for X: " + x);
		GUI.Button (new Rect (5, 55, 200, 40), "CurrentSpeed for Y: " + y);
        GUI.Button(new Rect(5, 105, 200, 40), "Player Height: " + this.transform.position.y);
        GUI.Button(new Rect(5, 155, 200, 40), "Water Height: " + WaterBehavior.waterHeight);
		if(death)
		{
			GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.1f, 200, 40), "You have died");
            this.rigidbody.velocity = new Vector3(0f, 0f, 0f);
		}
		
	}

	void Movement()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(isGrounded())
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
				rigidbody.AddForce (0, 150f, 0f);
			}
		}
		if(Input.GetKey(KeyCode.A))
		{
			if(rigidbody.velocity.x < MaxSpeed)
			{
				rigidbody.AddForce(50f, 0f ,0f);
			}
		}
		if(Input.GetKey(KeyCode.D))
		{
			if(rigidbody.velocity.x > -MaxSpeed)
			{
				rigidbody.AddForce(-50f, 0f ,0f);
			}
		}
		
		
		if(rigidbody.velocity.x > MaxSpeed)
		{
			rigidbody.velocity = new Vector3(MaxSpeed, 0f, 0f);
		}
		if(rigidbody.velocity.x < -MaxSpeed)
		{
			rigidbody.velocity = new Vector3(-MaxSpeed, 0f, 0f);
		}
	}

	bool isGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
	}
}
