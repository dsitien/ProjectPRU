using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int powerUpLvRequirement = 0;
    public Bullet bullet;
    public List<Sprite> bulletSprites;
    private int currentBulletSpriteIndex = 0;
    Vector2 direction;

    public float shootEverySecond = 1f;

    public bool isActive = false;
    private AudioManager audioManager;
    private Coroutine shootingCoroutine;

    void Awake()
    {
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    void Start()
    {
        GameObject audioManagerObject = GameObject.Find("AudioManager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene");
        }

        // Ensure initial state of gun based on powerUpLvRequirement
        SetGunState();
    }

    void OnEnable()
    {
        // Ensure isActive state is handled properly when the object is enabled
        if (isActive)
        {
            StartShooting();
        }
    }

    void OnDisable()
    {
        // Stop shooting when the object is disabled
        StopShooting();
    }

    void Update()
    {
        // Check isActive state and manage shooting coroutine
        if (isActive && shootingCoroutine == null)
        {
            StartShooting();
        }
        else if (!isActive && shootingCoroutine != null)
        {
            StopShooting();
        }
    }

    void StartShooting()
    {
        // Start the shooting coroutine
        shootingCoroutine = StartCoroutine(Shooting());
    }

    void StopShooting()
    {
        // Stop the shooting coroutine if it's running
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator Shooting()
    {
        while (isActive)
        {
            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            Bullet goBullet = go.GetComponent<Bullet>();
            goBullet.direction = direction;

            if (audioManager != null)
            {
                audioManager.PlaySFX("Gun");
            }

            SpriteRenderer bulletSpriteRenderer = go.GetComponent<SpriteRenderer>();
            if (bulletSpriteRenderer != null)
            {
                if (currentBulletSpriteIndex >= 0 && currentBulletSpriteIndex < bulletSprites.Count)
                {
                    bulletSpriteRenderer.sprite = bulletSprites[currentBulletSpriteIndex];
                }
                else
                {
                    Debug.LogWarning("Sprite index out of range");
                }
            }
            else
            {
                Debug.LogError("SpriteRenderer is missing on Bullet prefab.");
            }

            yield return new WaitForSeconds(shootEverySecond);
        }
    }

    public void ChangeBulletSprite(int spriteIndex)
    {
        if (spriteIndex >= 0 && spriteIndex < bulletSprites.Count)
        {
            currentBulletSpriteIndex = spriteIndex;
            SetGunState(); // Ensure gun state is updated after sprite change
        }
        else
        {
            Debug.LogWarning("Sprite index out of range");
        }
    }

    void SetGunState()
    {
        // Activate or deactivate the gun based on powerUpLvRequirement
        bool shouldBeActive = (powerUpLvRequirement == 0); // Adjust this condition as needed

        // Activate/deactivate the GameObject
        gameObject.SetActive(shouldBeActive);
    }
}
