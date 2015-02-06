using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]

public class RigidbodyController : MonoBehaviour
{
	public float xForce;  // Forward/Backward Force(speed)
	public float zForce;  // Sideways Force(speed)
	public float yForce;  // Jump Force(speed)

	Vector3 forward = Vector3.forward;
	Vector3 side = Vector3.right;      
	Vector3 up = Vector3.up;

	float gravity = 20.0f;

	Camera playerCamera;
	Rigidbody rigidbody;
	bool isGrounded;

	// Use this for initialization
	void Start ()
	{

		//Grab Rigidbody so we aren't calling it each cycle
		rigidbody = gameObject.GetComponent<Rigidbody>();
		playerCamera = Camera.main;

		//Set Up Initial Rigidbody Parameters
		rigidbody.useGravity = true;
		rigidbody.freezeRotation = true;
	}
	
	// Update is called once per phyisics cycle
	void FixedUpdate ()
	{	   	
		//Jump using "Jump" Button by adding force in y direction.
		if(isGrounded)
		{
			//Rigidbody.movePosition to walk in x and z directions
			//Add Force creates unwanted effects like sliding
			rigidbody.MovePosition(rigidbody.position + new Vector3(playerCamera.transform.forward.x,0,playerCamera.transform.forward.z) * xForce * Input.GetAxis("Vertical") * Time.deltaTime);
			rigidbody.MovePosition(rigidbody.position + new Vector3(playerCamera.transform.right.x,0,playerCamera.transform.right.z) * zForce * Input.GetAxis("Horizontal") * Time.deltaTime);

			if(Input.GetButton("Jump"))
			{

				rigidbody.AddForce(up * yForce, ForceMode.Impulse);
				Debug.Log(up * yForce * Time.deltaTime);
			}
		}
	}

	//Check If Player Is Grounded
	void OnCollisionStay (Collision collisionInfo)
	{
		isGrounded = true;
	}

	//Check If Player Is Not Grounded
	void OnCollisionExit (Collision collisionInfo)
	{
		isGrounded = false;
	}
}
