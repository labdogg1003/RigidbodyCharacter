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
	Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
		//Grab Rigidbody so we aren't calling it each cycle
		rigidbody = gameObject.GetComponent<Rigidbody>();

		//Set Up Initial Rigidbody Parameters
		rigidbody.useGravity = true;
		rigidbody.freezeRotation = true;
	}
	
	// Update is called once per phyisics cycle
	void FixedUpdate ()
	{
		//Rigidbody.movePosition to walk in x and z directions
		//Add Force creates unwanted effects like sliding
		rigidbody.MovePosition(rigidbody.position + forward * xForce * Input.GetAxis("Vertical") * Time.deltaTime);
		rigidbody.MovePosition(rigidbody.position + side * zForce * Input.GetAxis("Horizontal") * Time.deltaTime);
	   	

		//Jump using "Jump" Button by adding force in y direction.
	}
}
