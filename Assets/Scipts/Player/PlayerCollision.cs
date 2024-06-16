using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
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
}
