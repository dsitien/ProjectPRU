using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score; // Điểm số của người chơi
    public Text scoreText; // Text UI để hiển thị điểm số
  

    void Start()
    {
        score = 0; // Khởi tạo điểm số là 0
        UpdateScoreText(); // Cập nhật điểm số khi bắt đầu game
       
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
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text reference is missing or destroyed!");
            return;
        }
    }
    public int GetScore()
    {
        return score;
    }
}
