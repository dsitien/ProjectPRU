using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GameObject ship;
    public bool VP1;
    public bool VP2;
    public bool VP3;
    Gun[] guns;

    private void Awake()
    {
        guns = ship.GetComponentsInChildren<Gun>(true);
    }

    void Update()
    {
        // No need to update every frame for this logic
    }

    private void ActiveAllGun3()
    {
        foreach (Gun gun in guns)
        {
            gun.shootEverySecond = 0.25f;
        }
    }

    private void ActiveAllGun2()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1)
            {
                gun.isActive = true;
                gun.gameObject.SetActive(true);
            }
        }
    }

    private void ActiveAllGun()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.isActive = true;
                gun.gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator DisableAfterTime(float time, string vpType)
    {
        yield return new WaitForSeconds(time);
        switch (vpType)
        {
            case "VP1":
                DeactivateAllGun();
                VP1 = false;
                break;
            case "VP2":
                DeactivateAllGun2();
                VP2 = false;
                break;
            case "VP3":
                DeactivateAllGun3();
                VP3 = false;
                break;
        }
        Destroy(gameObject);
    }

    private void DeactivateAllGun()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }

    private void DeactivateAllGun2()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1)
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }

    private void DeactivateAllGun3()
    {
        foreach (Gun gun in guns)
        {
            gun.shootEverySecond = 0.75f; // or the default value
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (VP1)
            {
                ActiveAllGun();
                StartCoroutine(DisableAfterTime(5f, "VP1"));
            }
            if (VP2)
            {
                ActiveAllGun2();
                StartCoroutine(DisableAfterTime(5f, "VP1"));
            }
            if (VP3)
            {
                ActiveAllGun3();
                StartCoroutine(DisableAfterTime(5f, "VP3"));
            }
            HideItem();
        }
    }
    private void HideItem()
    {
        // Disable the renderer to make the object invisible
        if (TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.enabled = false;
        }

        // Disable the collider to prevent further interactions
        if (TryGetComponent<Collider2D>(out Collider2D collider))
        {
            collider.enabled = false;
        }
    }
}
