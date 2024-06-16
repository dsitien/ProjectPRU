using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript3 : MonoBehaviour
{
    public BulletEnemy bullet;          // Bullet prefab reference
    public BulletScript2 bullet2;        // Second bullet prefab reference


    public float shootIntervalSeconds = 0.5f; // Interval between shots
    public float shootDelaySeconds = 0.2f;    // Delay before shooting starts
  


    public int powerUpRequirement = 0;   // Power-up requirement for gun
    public float autoShootDistance = 10; // Distance within which auto shoot is enabled


    public bool isActive = false;        // Flag to check if gun is active
    public bool autoShoot = false;       // Flag for automatic shooting


    public Transform bulletPos;          // Position to instantiate bullets from
    private GameObject player;           // Reference to the player object
    private Vector2 direction;           // Direction in which the gun is facing


    public enum BulletType { Bullet1, Bullet2 } // Enum for bullet types
    public BulletType selectedBulletType = BulletType.Bullet1; // Default selected bullet type

    private Coroutine shootingCoroutine; // Coroutine for handling shooting

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        // Calculate the direction the gun is facing
        direction = (transform.localRotation * Vector2.right).normalized;

        // Calculate the distance between the gun and the player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < autoShootDistance && autoShoot)
        {
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootRoutine());
            }
        }
        else
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }
    }



    private IEnumerator ShootRoutine()
    {
        // Initial delay before shooting starts
        yield return new WaitForSeconds(shootDelaySeconds);

        while (true)
        {
            Shoot();

            // Wait for the interval between shots
            yield return new WaitForSeconds(shootIntervalSeconds);
        }
    }



    // Method to shoot a bullet based on the selected bullet type
    public void Shoot()
    {
        switch (selectedBulletType)
        {
            case BulletType.Bullet1:
                ShootBullet1();
                break;
            case BulletType.Bullet2:
                ShootBullet2();
                break;
        }
    }



    // Method to shoot Bullet1
    public void ShootBullet1()
    {
        GameObject go = Instantiate(bullet.gameObject, bulletPos.position, Quaternion.identity);
        BulletEnemy bulletWay = go.GetComponent<BulletEnemy>();
        bulletWay.direction = direction;
    }

    // Method to shoot Bullet2
    public void ShootBullet2()
    {
        GameObject go2 = Instantiate(bullet2.gameObject, bulletPos.position, Quaternion.identity);
        // Add any additional setup for bullet2 if needed
    }
}
