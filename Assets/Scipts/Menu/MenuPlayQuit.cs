using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayQuit : MonoBehaviour
{
    public string sceneName;

    public void Play() {
       
        SceneManager.LoadScene(sceneName);
    }
    public void Guide() {
       
        SceneManager.LoadScene("Guide");
    }
    public void AboutUs() {
       
        SceneManager.LoadScene("AboutUs");
    }
    public void Quit()
    {

       Application.Quit();
    }
}
