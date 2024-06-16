using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlSound : MonoBehaviour
{
  public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    } 
    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolumn()
    {
        AudioManager.Instance.MusicVolumn(_musicSlider.value);

    }  
    public void SfxVolumn()
    {
        AudioManager.Instance.SfxVolumn(_sfxSlider.value);

    }
}
