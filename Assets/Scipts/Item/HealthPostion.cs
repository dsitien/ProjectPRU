using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPostion : MonoBehaviour
{
    public PlayerCollision playerCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCollision.hit();
            Destroy(gameObject);
        }
    }
}
