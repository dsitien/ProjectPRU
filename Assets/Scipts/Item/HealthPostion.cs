using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPostion : MonoBehaviour
{
    private PlayerCollision playerCollision;

    private void Awake()
    {
        GameObject ship = GameObject.Find("Ship");

        if (ship != null)
        {
            // Gán component PlayerCollision của ship vào playerCollision
            playerCollision = ship.GetComponent<PlayerCollision>();

            if (playerCollision == null)
            {
                Debug.LogError("GameObject 'ship' does not have a PlayerCollision component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject found with the name 'ship'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCollision.hit();
            Destroy(gameObject);
        }
    }
}
