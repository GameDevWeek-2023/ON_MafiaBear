using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    //~ inspector (private)
    [SerializeField][Tooltip("The volume sliders in scene")]
    private Slider masterSlider, musicSlider, sfxSlider;

    [SerializeField][Tooltip("The sound toggle in scene")]
    private Toggle masterVolume;

    //~ unity methods (private)
    private void Start() {
        masterVolume.isOn = PlayerPrefs.GetInt("MasterToggle", 1) == 1;
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    //~ public methods
    /// <summary> Toggles the master volume and saves value in the <see cref="PlayerPrefs"/> </summary>
    public void ToggleMasterVolume(){
        SoundManager.Instance.ToggleMasterVolume(masterVolume.isOn);
        PlayerPrefs.SetInt("MasterToggle", masterVolume.isOn ? 1 : 0);
    }

    /// <summary> Sets the master volume and saves value in the <see cref="PlayerPrefs"/> </summary>
    public void MasterVolume(){
        SoundManager.Instance.MasterVolume(musicSlider.value, sfxSlider.value, masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    /// <summary> Sets the music volume and saves value in the <see cref="PlayerPrefs"/> </summary>
    public void MusicVolume(){
        SoundManager.Instance.MusicVolume(musicSlider.value, masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    /// <summary> Sets the SFX volume and saves value in the <see cref="PlayerPrefs"/> </summary>
    public void SFXVolume(){
        SoundManager.Instance.SFXVolume(sfxSlider.value, masterSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
}
