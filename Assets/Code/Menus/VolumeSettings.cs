using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        mixer = audioManager.audioMixer;

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0f);

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music",volume);
        PlayerPrefs.SetFloat("MusicVolume",volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX",volume);
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master",volume);
        PlayerPrefs.SetFloat("MasterVolume",volume);
    }
}
