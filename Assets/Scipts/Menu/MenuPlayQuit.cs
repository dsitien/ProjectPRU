using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound_Menu;
    public void Play() {
        sound_Menu.Stop();
        SceneManager.LoadScene("Test");
    }
    public void Sound() {
       
        SceneManager.LoadScene("SettingSound");
    }
    public void Quit()
    {

       Application.Quit();
    }
}
