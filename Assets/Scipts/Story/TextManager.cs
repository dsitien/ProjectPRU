using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text[] texts;
    private int currentTextIndex = 0; 

    void Start()
    {
        for (int i = 1; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextText();
        }
    }

    void ShowNextText()
    {
        if (currentTextIndex < texts.Length - 1)
        {
            texts[currentTextIndex].gameObject.SetActive(false);
            currentTextIndex++;
            texts[currentTextIndex].gameObject.SetActive(true);
        }
       
    }
}