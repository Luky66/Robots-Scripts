using UnityEngine;

[System.Serializable]
public class PlayerWeapon {

	public string name = "Glock";

	public int damage = 10;
	public float range = 200f;

	public float fireRate = 0f; // 0 is single-fire everything higher is rapid-fire

	public GameObject graphics;
}
