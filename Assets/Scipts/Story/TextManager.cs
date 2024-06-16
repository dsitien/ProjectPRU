using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text[] texts; // Mảng chứa các đối tượng Text
    private int currentTextIndex = 0; // Chỉ số của dòng text hiện tại

    void Start()
    {
        // Ẩn tất cả các đối tượng Text trừ dòng text đầu tiên
        for (int i = 1; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Kiểm tra sự kiện nhấp chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            // Hiển thị dòng text tiếp theo (nếu có)
            ShowNextText();
        }
    }

    void ShowNextText()
    {
        // Kiểm tra nếu vẫn còn dòng text tiếp theo để hiển thị
        if (currentTextIndex < texts.Length - 1)
        {
            // Ẩn dòng text hiện tại
            texts[currentTextIndex].gameObject.SetActive(false);

            // Tăng chỉ số để chuyển sang dòng text tiếp theo
            currentTextIndex++;

            // Hiển thị dòng text tiếp theo
            texts[currentTextIndex].gameObject.SetActive(true);
        }
    }
}