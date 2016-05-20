using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour 
{
	public float maxTorque = 50f;
	public float steerFoce = 2f;
	public float maxSteerAngle = 35f;


	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] tireMeshes = new Transform[4];

	//private Transform minigun;

	void Start()
	{
		
	}

	void Update()
	{
		UpdateMeshPositions ();

	}

	void FixedUpdate()
	{
		float steer = Input.GetAxis ("Horizontal");
		float accelerate = Input.GetAxis ("Vertical");

		float finalAngle = steer * maxSteerAngle;

		wheelColliders [0].steerAngle = finalAngle;
		wheelColliders [1].steerAngle = finalAngle;

		for (int i = 0; i < 4; i++) 
		{
			wheelColliders [i].motorTorque = accelerate * maxTorque;
		}
	}

	void UpdateMeshPositions()
	{
		for (int i = 0; i < 4; i++) 
		{
			Quaternion quat;
			Vector3 pos;
			wheelColliders [i].GetWorldPose (out pos, out quat);

			tireMeshes [i].parent.position = pos;
			tireMeshes [i].parent.rotation = quat;
		}
	}
}
