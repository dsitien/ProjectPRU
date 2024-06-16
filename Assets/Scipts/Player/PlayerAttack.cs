using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	Gun[] guns;

	void Start()
	{
		guns = transform.GetComponentsInChildren<Gun>();
		foreach (Gun gun in guns)
		{
			gun.isActive = true;
			if (gun.powerUpLvRequirement != 0)
			{
				gun.gameObject.SetActive(false);
			}
		}
	}

	void Update()
	{
		foreach (Gun gun in guns)
		{
			if (gun.gameObject.activeSelf)
			{
				gun.isActive = true; // Kích hoạt chế độ auto-shoot
			}
		}
	}
}
