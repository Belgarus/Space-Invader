using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private SettingsData settingsData;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private AudioMixer audioMixer;

    void Start()
    {
       volumeSlider.value = settingsData.volume;
       audioMixer.SetFloat("MasterVolume", settingsData.volume);
       fullScreenToggle.isOn = settingsData.isFullScreen;
       Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnToggleChange(bool isOn)
    {
        Screen.fullScreen = isOn;
        settingsData.isFullScreen = isOn;
    }

    public void OnVolumeChange()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("MasterVolume", volume);
        settingsData.volume = volume;
    }
}