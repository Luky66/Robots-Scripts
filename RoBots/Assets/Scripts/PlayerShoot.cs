﻿using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof (WeaponManager))]
public class PlayerShoot : NetworkBehaviour {

	private const string PLAYER_TAG = "Player";

	private PlayerWeapon currentWeapon;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	private WeaponManager weaponManager;

	void Start ()
	{
		if (cam == null) 
		{
			Debug.LogError("PlayerShoot: No camera referenced!");
			this.enabled = false;
		}

		weaponManager = GetComponent<WeaponManager>();
	}

	void Update ()
	{
		currentWeapon = weaponManager.GetCurrentWeapon();

		if (currentWeapon.fireRate <= 0f) 
		{
			// Single-Fire
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else 
		{
			if (Input.GetButtonDown ("Fire1")) {
				InvokeRepeating ("Shoot", 0f, 1f / currentWeapon.fireRate);
			} else if (Input.GetButtonUp ("Fire1")) 
			{
				CancelInvoke ("Shoot");
			}
		}

	}

	[Client]
	void Shoot ()
	{
		Debug.Log("SHOOT!");

		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.range, mask)) 
		{
			// We hit something.
			if (_hit.collider.tag == PLAYER_TAG) 
			{
				CmdPlayerShot (_hit.collider.transform.root.name, currentWeapon.damage);
			}
		}
	}

	[Command]
	void CmdPlayerShot (string _playerID, int _damage)
	{
		Debug.Log(_playerID + " has been shot.");

		Player _player = GameManager.GetPlayer (_playerID);
		_player.RpcTakeDamage (_damage);
	}
}
