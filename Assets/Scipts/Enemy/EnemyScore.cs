using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    public int scoreValue = 10; // Giá trị điểm của vật phẩm này

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPlayer") || collision.CompareTag("Player"))
        {
           
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                
                scoreManager.AddScore(scoreValue);
                Debug.Log("hi");
            }
         
        }
    }
    }
