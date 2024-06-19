using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int powerUpLvRequirement = 0;
    public Bullet bullet;
    public List<Sprite> bulletSprites; // Danh sách các sprite của viên đạn
    private int currentBulletSpriteIndex = 0; // Chỉ số sprite hiện tại
    Vector2 direction;

    public float shootEverySecond;

    bool canShoot = true;

    public bool isActive = false;

    void Start()
    {
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    void Update()
    {
        if (!isActive) return;

        // Tính toán hướng bắn
        direction = (transform.localRotation * Vector2.up).normalized;

        // Tự động bắn
        if (canShoot)
        {
            StartCoroutine(Shooting());
        }
    }

    private IEnumerator Shooting()
    {
        canShoot = false;
      

        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;

        // Thay đổi sprite viên đạn ngay khi nó được instantiate
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
        canShoot = true;
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
