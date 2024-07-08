using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScore : MonoBehaviour
{
    public int scoreValue = 100; // Giá trị điểm của vật phẩm này

    private void OnDestroy()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }

    }
}
