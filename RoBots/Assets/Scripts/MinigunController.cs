using UnityEngine;
using System.Collections;

public class MinigunController : MonoBehaviour {

	public float minigunRPM;
	public float aimSensitivity = 3f;

	public Transform minigunShaft;
	public Transform RotatingMinigunPart;
	public Transform TiltingMinigunPart;

	private Quaternion minigunShaftQuat;
	private Vector3 yAimVector;
	private Vector3 xAimVector;
	private Quaternion minigunYAimQuat;
	private Quaternion minigunXAimQuat;
	private float minigunRotation;
	private float minigunRPS;
	private float minigunAnglePerSecond;
	private float minigunShootingRPS;

	// Use this for initialization
	void Start () 
	{
	
		minigunRPS = minigunRPM / 60;
		minigunAnglePerSecond = minigunRPS * 360;
		minigunShootingRPS = minigunRPS / 6;

		//print (minigunShootingRPS);

	}

	void Update()
	{
		// Calculate rotatino as a 3D Vector
		float _yRot = Input.GetAxisRaw ("Mouse X");
		float _xRot = Input.GetAxisRaw ("Mouse Y");
		yAimVector = new Vector3 (0f, _yRot, 0f) * aimSensitivity;
		xAimVector = new Vector3 (-_xRot, 0f, 0f) * aimSensitivity;

		moveMinigun (yAimVector, xAimVector);

		// Stop Minigun from moving to far sideways
		if (RotatingMinigunPart.localRotation.eulerAngles.y < 340 && RotatingMinigunPart.localRotation.eulerAngles.y > 180) 
		{
			minigunYAimQuat.eulerAngles = new Vector3 (0f, -20f, 0f); //+ RotatingMinigunPart.parent.localRotation.eulerAngles;
			RotatingMinigunPart.localRotation = minigunYAimQuat;
		}
		if (RotatingMinigunPart.localRotation.eulerAngles.y > 20 && RotatingMinigunPart.localRotation.eulerAngles.y < 180) 
		{
			minigunYAimQuat.eulerAngles = new Vector3(0f, 20f, 0f);// + RotatingMinigunPart.parent.localRotation.eulerAngles;
			RotatingMinigunPart.localRotation = minigunYAimQuat;
		}
	
		//print (TiltingMinigunPart.localRotation.eulerAngles);

		// Stop Minigun from moving to far up- or downwards
		if (TiltingMinigunPart.localRotation.eulerAngles.x < 340 && TiltingMinigunPart.localRotation.eulerAngles.x > 180) 
		{
			minigunXAimQuat.eulerAngles = new Vector3 (-20f, 0f, 0f);// + TiltingMinigunPart.parent.localRotation.eulerAngles;
			TiltingMinigunPart.localRotation = minigunXAimQuat;
		}
		if (TiltingMinigunPart.localRotation.eulerAngles.x > 10 && TiltingMinigunPart.localRotation.eulerAngles.x < 180) 
		{
			minigunXAimQuat.eulerAngles = new Vector3 (10f, 0f, 0f);// + TiltingMinigunPart.parent.localRotation.eulerAngles;
			TiltingMinigunPart.localRotation = minigunXAimQuat;
		}



	}

	// Update is called once per frame
	void FixedUpdate () 
	{
	
		if (Input.GetButton("Fire1")) 
		{
			minigunRotation = minigunRotation + (minigunAnglePerSecond * Time.deltaTime);
			//print (minigunAnglePerSecond * Time.deltaTime);
			//print (Time.deltaTime);
			minigunShaftQuat.eulerAngles = new Vector3 (minigunShaft.rotation.eulerAngles.x, minigunShaft.rotation.eulerAngles.y, minigunRotation);
			minigunShaft.rotation = minigunShaftQuat;
		}

	}

	void moveMinigun (Vector3 yVector, Vector3 xVector)
	{
		minigunYAimQuat.eulerAngles = yVector + RotatingMinigunPart.localRotation.eulerAngles;
		RotatingMinigunPart.localRotation = minigunYAimQuat;

		minigunXAimQuat.eulerAngles = xVector + TiltingMinigunPart.localRotation.eulerAngles;
		TiltingMinigunPart.localRotation = minigunXAimQuat;
	}
}


