using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score; // Điểm số của người chơi
    public string scoreTextObjectName = "Score"; // Tên của GameObject chứa Text UI
    private Text scoreText; // Text UI để hiển thị điểm số

    void Start()
    {
        // Tìm đối tượng Text trong Scene
        GameObject scoreTextObject = GameObject.Find(scoreTextObjectName);

        // Kiểm tra xem đối tượng có được tìm thấy hay không
        if (scoreTextObject != null)
        {
            // Lấy component Text từ đối tượng
            scoreText = scoreTextObject.GetComponent<Text>();

            if (scoreText == null)
            {
                Debug.LogError("Text component is not found on the ScoreText GameObject!");
                return;
            }
        }
        else
        {
            Debug.LogError("Score Text GameObject is not found!");
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
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogError("Score Text UI element is not assigned!");
        }
    }
}
