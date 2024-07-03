using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinAll : MonoBehaviour
{
    public ShipChangeSkin ship; // Tham chiếu tới ShipChangeSkin
    public GameObject skin;

    public List<Button> skinButtons; // Danh sách các nút skin
    public Color selectedColor = Color.blue; // Màu sắc khi được chọn
    public Color defaultColor = Color.white; // Màu sắc mặc định

    private void Awake()
    {
        skin.SetActive(false);
        // Đặt màu mặc định cho tất cả các nút
        ResetButtonColors();
        // Đặt màu cho nút mặc định (skinIndex = 0)
        if (skinButtons.Count > 0)
        {
            skinButtons[0].GetComponent<Image>().color = selectedColor;
        }
    }

    public void ChangeBulletAndShipSkin(int skinIndex)
    {
        if (ship != null)
        {
            ship.ChangeShipSkin(skinIndex);
            UpdateButtonColors(skinIndex); // Cập nhật màu sắc các nút
        }
        else
        {
            Debug.LogError("ShipChangeSkin reference is missing in ChangeSkinAll script.");
        }
    }

    public void TurnOnPanel()
    {
        skin.SetActive(true);
    }

    public void Close()
    {
        skin.SetActive(false);
    }

    private void UpdateButtonColors(int selectedIndex)
    {
        for (int i = 0; i < skinButtons.Count; i++)
        {
            Image buttonImage = skinButtons[i].GetComponent<Image>();
            if (i == selectedIndex)
            {
                buttonImage.color = selectedColor;
            }
            else
            {
                buttonImage.color = defaultColor;
            }
        }
    }

    private void ResetButtonColors()
    {
        foreach (Button button in skinButtons)
        {
            button.GetComponent<Image>().color = defaultColor;
        }
    }
}
