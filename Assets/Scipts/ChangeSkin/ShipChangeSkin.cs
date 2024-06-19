using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChangeSkin : MonoBehaviour
{
    public List<Sprite> shipSprites; // Danh sách các sprite của tàu
    private SpriteRenderer spriteRenderer;
    private Gun[] guns; // Mảng các Gun trong Ship

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        guns = GetComponentsInChildren<Gun>(); // Lấy tất cả các Gun trong Ship
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned in ShipChangeSkin script.");
        }
    }

    public void ChangeShipSkin(int spriteIndex)
    {
        if (spriteIndex >= 0 && spriteIndex < shipSprites.Count)
        {
            spriteRenderer.sprite = shipSprites[spriteIndex];
            // Thay đổi sprite của tất cả các Gun trong Ship
            foreach (Gun gun in guns)
            {
                gun.ChangeBulletSprite(spriteIndex);
            }
        }
        else
        {
            Debug.LogWarning("Sprite index out of range");
        }
    }
}
