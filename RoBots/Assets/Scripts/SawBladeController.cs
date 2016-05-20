using UnityEngine;
using System.Collections;

public class SawBladeController : MonoBehaviour {

	public Transform sparksPrefab;

	AudioSource audio;

	[SerializeField]
	private Transform sawBlade;

	[SerializeField]
	private float rotationSpeed;

	private float sawBladeRotation;
	private Quaternion sawBladeQuat;

	void Update()
	{
		if (Input.GetButton ("Fire2")) 
		{
			sawBladeRotation = sawBladeRotation + ((rotationSpeed * -100) * Time.deltaTime);
			//print (sawBladeAnglePerSecond * Time.deltaTime);
			//print (Time.deltaTime);
			sawBladeQuat.eulerAngles = new Vector3 (0f, sawBladeRotation, 0f);
			sawBlade.localRotation = sawBladeQuat;
		}
	}
}
