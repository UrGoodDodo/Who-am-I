using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{

    public AudioMixer audioMixer; // Пока не знаю но вроде как звук в игре

    Resolution[] resolutions; // массив разрешений экрана игрока

    FullScreenMode[] fullscreenmodes;

    public Dropdown fullscreenDropdown;

    private int fullscreenModeIndex;

    private int oldfullscreenModeIndex;

    private int newfullscreenModeIndex;

    public Dropdown resolutionDropdown; //Список из разрешений экрана игрока в меню настроек в кнопке

    public Dropdown qualityDropdowm; // Список пресетов качеств в меню настроек в кнопке

    public Slider volumeSlider; // слайдер звука в меню настроек

    private float oldvolume; // значение параметра звук для старых настроек

    private int oldqualityIndex; // индекс пресета качества для старых настроек

    private int oldresolutionIndex; // индекс разрешения для старых настроек

    private float newvolume; // значение параметра звук для новых настроек

    private int newqualityIndex; // индекс пресета качества для новых настроек

    private int newresolutionIndex; // индекс разрешения для новых настроек

    void Start()
    {
        fullscreenmodes = new FullScreenMode[3];
        fullscreenmodes[0] = FullScreenMode.ExclusiveFullScreen;
        fullscreenmodes[1] = FullScreenMode.Windowed;
        fullscreenmodes[2] = FullScreenMode.FullScreenWindow;
        fullscreenDropdown.ClearOptions();
        List<string> fsmoptions = new List<string>();
        fsmoptions.Add("Полноэкранный");
        fsmoptions.Add("Оконный");
        fsmoptions.Add("Оконный без рамок");
        fullscreenDropdown.AddOptions(fsmoptions);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
        StartLoadSettings();
    }


    public void StartLoadSettings()
    {
        oldvolume = PlayerPrefs.GetFloat("Volume");
        oldfullscreenModeIndex = PlayerPrefs.GetInt("FullScreenMode");
        oldresolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        oldqualityIndex = PlayerPrefs.GetInt("QualityIndex");
        volumeSlider.value = oldvolume;
        resolutionDropdown.value = oldresolutionIndex;
        fullscreenDropdown.value = oldfullscreenModeIndex;
        qualityDropdowm.value = oldqualityIndex;
    }

    public void SetNewResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate);
        newresolutionIndex = resolutionIndex;
    }

    public void SetNewQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        newqualityIndex = qualityIndex;
    }

    public void SetNewVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        newvolume = volume;
    }

    public void SetNewFullScreenMode(int fullscreenmodeIndex)
    {
        Screen.fullScreenMode = fullscreenmodes[fullscreenmodeIndex];
        newfullscreenModeIndex = fullscreenmodeIndex;
    }

    public void SaveButton()
    {
        oldfullscreenModeIndex = newfullscreenModeIndex;
        oldqualityIndex = newqualityIndex;
        oldresolutionIndex = newresolutionIndex;
        oldvolume = newvolume;
        SaveSettings(oldvolume, oldqualityIndex, oldresolutionIndex, oldfullscreenModeIndex);
    }
    public void SaveSettings(float v, int indq, int indr, int indf)
    {

        PlayerPrefs.SetInt("FullScreenMode", indf);
        PlayerPrefs.SetFloat("Volume", v);
        PlayerPrefs.SetInt("QualityIndex", indq);
        PlayerPrefs.SetInt("ResolutionIndex", indr);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && oldresolutionIndex != newresolutionIndex)
        {
            SetVolume(oldvolume, volumeSlider);
            SetQuality(oldqualityIndex, qualityDropdowm);
            SetResolution(oldresolutionIndex,resolutionDropdown);
            SetFullScreenMode(oldresolutionIndex, fullscreenDropdown);
        }
    }

    public void SetVolume(float volume, Slider volumeS) // функция изменения звука
    {
        audioMixer.SetFloat("Volume", volume);
        volumeS.value = volume;
    }

    public void SetQuality(int qualityIndex, Dropdown qualityDd) // функция изменения качества
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityDd.value = qualityIndex;
    }

    public void SetFullScreenMode(int fullscreenmodeIndex, Dropdown fullscreenmodeDD)
    {
        Screen.fullScreenMode = fullscreenmodes[fullscreenmodeIndex];
        fullscreenmodeDD.value = fullscreenmodeIndex;
    }


    public void SetResolution(int resolutionIndex, Dropdown resolutionDD) // функция смены разрешения
    {
        Resolution resolution = resolutions[resolutionIndex]; // для удобства создаем переменную разрешения в которую записываем то разрешение на которое меняем
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate); // меняем разрешение
        resolutionDD.value = resolutionIndex;
    }
}
