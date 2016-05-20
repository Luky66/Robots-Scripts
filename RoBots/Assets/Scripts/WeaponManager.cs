using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour {

	[SerializeField]
	private string weaponLayerName = "Weapon";

	//Weapon Ankers
	[SerializeField]
	private Transform weaponAnkerTop;

	[SerializeField]
	private Transform weaponAnkerFront;

	[SerializeField]
	private Transform weaponAnkerRear;

	[SerializeField]
	private PlayerWeapon weaponTop;

	[SerializeField]
	private PlayerWeapon weaponFront;

	[SerializeField]
	private PlayerWeapon weaponRear;

	private PlayerWeapon currentWeapon;
	private WeaponGraphics currentGraphics;

	void Start () 
	{
		EquipWeapon (weaponTop, weaponAnkerTop);
		EquipWeapon (weaponFront, weaponAnkerFront);
	}

	public PlayerWeapon GetCurrentWeapon ()
	{
		return currentWeapon;
	}

	public WeaponGraphics GetCurrentGraphics ()
	{
		return currentGraphics;
	}
	
	void EquipWeapon (PlayerWeapon _weapon, Transform _weaponAnker)
	{
		currentWeapon = _weapon;

		GameObject _weaponIns = (GameObject)Instantiate (_weapon.graphics, _weaponAnker.position, _weaponAnker.rotation);
		_weaponIns.transform.SetParent (_weaponAnker);

		/*
		currentGraphics = GetComponent<WeaponGraphics> ();
		if (currentGraphics == null)
			Debug.LogError ("No WeaponGraphics component on the weapon object: " + _weaponIns.name);
		*/

		///*
		if (isLocalPlayer)
			Util.SetLayerRecursively (_weaponIns, LayerMask.NameToLayer (weaponLayerName));
		//*/
	}

}
