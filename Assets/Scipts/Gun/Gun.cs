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
      
        direction = (transform.localRotation * Vector2.up).normalized;

    }

   
    void Update()
    {
        if (isActive && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(Shooting());
        }
        else if (!isActive && shootingCoroutine != null)
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
        }
        else
        {
            Debug.LogWarning("Sprite index out of range");
        }
    }
}
