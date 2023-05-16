using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    private Resolution[] _resolutions;
    public TMP_Dropdown resDropdown;
    public TextMeshProUGUI volumeText;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixMode mixMode;
    [SerializeField] private Slider volumeSlider;

    public enum AudioMixMode {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }


    private void Start() {
        LoadValue();

        _resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> resOptions = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++) {
            string option = _resolutions[i].width + " x " + _resolutions[i].height + " [" + _resolutions[i].refreshRate + "hz]";
            resOptions.Add(option);

            if (_resolutions[i].width == Screen.width &&
                _resolutions[i].height == Screen.height) {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume) {
        volumeText.SetText($"{volume.ToString("0.0")}");
        switch (mixMode) {
            case AudioMixMode.LinearAudioSourceVolume:
                audioSource.volume = volume;
                break;
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat("Volume", (-80 + volume * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
                break;
        }
    }
    public void SetFullscreen(bool isFullscreen) {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution(int resIndex) {
            Resolution res = _resolutions[resIndex];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }

        public void SaveVolume() {
            float volumeValue = volumeSlider.value;
            PlayerPrefs.SetFloat("VolumeValue", volumeSlider.value);
            LoadValue();
        }
        
        private void LoadValue() {
            float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
            volumeSlider.value = volumeValue;
            mixer.SetFloat("Volume", Mathf.Log10(volumeValue) * 20);
        }
}
