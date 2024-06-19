using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score; // Điểm số của người chơi
    public Text scoreText; // Text UI để hiển thị điểm số

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text UI element is not assigned in the Inspector!");
            return;
        }

        score = 0; // Khởi tạo điểm số là 0
        UpdateScoreText();
    }

    // Hàm để thêm điểm
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText(); // Cập nhật điểm số mỗi khi có sự thay đổi
    }

    // Hàm để cập nhật Text UI hiển thị điểm số
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text UI element is not assigned!");
        }
    }
}
