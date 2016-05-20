using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public Rigidbody bullet;
	public Light fireLight;
	public float speed = 30;

	private float minigunShootingRPS = 0.1f;
	private float timeLastShotFired = 0;
	
	// Update is called once per frame

	void Start ()
	{
		fireLight.enabled = false;
	}


	void Update ()
	{
		if (fireLight.enabled) 
		{
			fireLight.enabled = false;
		}

		if (Input.GetButton("Fire1") && (Time.time > timeLastShotFired + minigunShootingRPS)) {
			Rigidbody bulletClone = Instantiate (bullet, transform.position, transform.rotation)as Rigidbody;
			fireLight.enabled = true;
			bulletClone.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
			timeLastShotFired = Time.time;

			Destroy (bulletClone.gameObject, 3);
		}
	}
}

/*

//Script from website: http://forum.unity3d.com/threads/gun-shooting-script-c.222057/

using UnityEngine;
using System.Collections;
 
public class ShootDemo : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
 
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
        }
    }
}
*/