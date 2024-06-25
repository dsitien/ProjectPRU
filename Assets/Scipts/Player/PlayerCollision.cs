using System;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public event Action ShieldDeactivated; // Sự kiện để thông báo khi Shield kết thúc

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isShielded = false; // Biến để kiểm tra xem người chơi có đang trong trạng thái bảo vệ hay không

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.CompareTag("Enemy") || collision.CompareTag("BulletEnemy") || collision.CompareTag("Boss"))
            {
                hit();
            }
        
    }

    public void hit()
    {
        PlayerHeart.health--;
        if (PlayerHeart.health <= 0)
        {
            // Xử lý khi hết máu (ví dụ: kết thúc game, hiển thị thông báo thua)
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < 5; i++)
        {
            SetTransparency(0.5f);
            yield return new WaitForSeconds(0.2f);
            SetTransparency(1f);
            yield return new WaitForSeconds(0.2f);
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    void SetTransparency(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }



    public void Heal()
    {
        PlayerHeart.health++;
        if (PlayerHeart.health > 3)
        {
            PlayerHeart.health = 3;
        }
    }
}
