using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayQuit : MonoBehaviour
{
    // Start is called before the first frame update
    //public AudioSource sound_Menu;
    public void Play() {
       
        SceneManager.LoadScene("MapGame1");
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
