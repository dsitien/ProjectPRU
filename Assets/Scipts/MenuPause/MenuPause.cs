using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public GameObject pausePanel;
    public Button pauseButton;
    public Button resumeButton;  
    public Button rePlayButton;
    public Button backMenuButton;
    public string nameScene;
    
    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        backMenuButton.onClick.AddListener(BackMenu);
        rePlayButton.onClick.AddListener(RePlay);
    }

    void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }  
    void BackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }  
    void RePlay()
    {
        Time.timeScale = 1;
        StopAllCoroutines();
        SceneManager.LoadScene(nameScene);
    }
}
