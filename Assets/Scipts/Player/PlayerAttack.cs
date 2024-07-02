using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Gun[] guns;

    private void Awake()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Start()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 0)
            {
                gun.gameObject.SetActive(true);
                gun.isActive = true;
            }
            else
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        foreach (Gun gun in guns)
        {
            gun.isActive = gun.gameObject.activeSelf;
        }
    }
}
