using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	Gun[] guns;

    private void Awake()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(true);
            gun.isActive = true;
            if (gun.powerUpLvRequirement != 0)
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }
    void Start()
	{
		
	}

	void Update()
	{
		
            foreach (Gun gun in guns)
            {
            gun.isActive = gun.gameObject.activeSelf;
        }
        
	
	}
}
