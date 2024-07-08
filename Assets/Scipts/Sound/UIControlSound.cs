using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlSound : MonoBehaviour
{
   public Slider _musicSlider, _sfxSlider;

    public AudioManager audio;
    public void ToggleMusic()
    {
        audio.ToggleMusic();
        
    } 
    public void ToggleSfx()
    {
       audio.ToggleSFX();
    }

    public void MusicVolumn()
    {
        audio.MusicVolume(_musicSlider.value);

    }  
    public void SfxVolumn()
    {
        audio.SfxVolume(_sfxSlider.value);

    }
}
