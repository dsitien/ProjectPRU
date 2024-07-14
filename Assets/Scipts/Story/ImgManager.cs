using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgManager : MonoBehaviour
{
    public Image[] img; 
    private int currentIndex = 0; 

    void Start()
    {
      
        for (int i = 1; i < img.Length; i++)
        {
            img[i].gameObject.SetActive(false);
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
       
        if (currentIndex < img.Length - 1)
        {         
            img[currentIndex].gameObject.SetActive(false);     
            currentIndex++;
            img[currentIndex].gameObject.SetActive(true);
        } 
       


    }
}
