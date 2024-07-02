using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgManager : MonoBehaviour
{
    public Image[] img; // Mảng chứa các đối tượng Text
    private int currentIndex = 0; // Chỉ số của dòng text hiện tại

    void Start()
    {
        // Ẩn tất cả các đối tượng Text trừ dòng text đầu tiên
        for (int i = 1; i < img.Length; i++)
        {
            img[i].gameObject.SetActive(false);
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
        if (currentIndex < img.Length - 1)
        {
            // Ẩn dòng text hiện tại
            img[currentIndex].gameObject.SetActive(false);

            // Tăng chỉ số để chuyển sang dòng text tiếp theo
            currentIndex++;

            // Hiển thị dòng text tiếp theo
            img[currentIndex].gameObject.SetActive(true);
        }
    }
}
