using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChangeSkin : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Biến spriteRenderer

    public List<Sprite> bulletSprites; // Danh sách các sprite của viên đạn

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned in BulletChangeSkin script.");
        }
    }

    public void ChangeBulletSprite(int spriteIndex)
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned in BulletChangeSkin script. Cannot change sprite."); 
            return;
        }

        if (spriteIndex >= 0 && spriteIndex < bulletSprites.Count)
        {
            spriteRenderer.sprite = bulletSprites[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Sprite index out of range"); 
        }
    }
}
