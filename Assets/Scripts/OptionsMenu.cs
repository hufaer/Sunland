using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer effectsMixer;
    public AudioMixer musicMixer;
    public Dropdown resolutinDropdown;
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider effectsSlider;
    public UnityEngine.UI.Toggle fullScreenCheck;

    private Resolution[] resolutions;

    private void Start()
    {
        fullScreenCheck.isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;

        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        resolutinDropdown.ClearOptions();
        List<string> resolutionStrings = new List<string>();
        int resIndex = 0;
        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (resolutions[i].height == Screen.height && resolutions[i].width == Screen.width)
            {
                resIndex = i;
            }
            resolutionStrings.Add(resolutions[i].width + " x " + resolutions[i].height);
        }
        resolutinDropdown.AddOptions(resolutionStrings);
        resolutinDropdown.value = resIndex;
        resolutinDropdown.RefreshShownValue();
        
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetEffectsVolume(float volume)
    {
        effectsMixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
