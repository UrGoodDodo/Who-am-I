using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
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

    private bool flag = true;

    void Start() 
    {
        LoadFlag();
        //Первый старт игры
        if (flag)
        {
            oldvolume = -60;
            SetVolume(oldvolume, volumeSlider);

            oldqualityIndex = 6;
            SetQuality(oldqualityIndex, qualityDropdowm);
            qualityDropdowm.value = oldqualityIndex;

            fullscreenmodes = new FullScreenMode[3]; // создаем массив режимов экрана
            fullscreenmodes[0] = FullScreenMode.ExclusiveFullScreen; // добавляем Полноэкранный
            fullscreenmodes[1] = FullScreenMode.Windowed; // добавляем Оконный
            fullscreenmodes[2] = FullScreenMode.FullScreenWindow; // добавляем Оконный без рамок
            fullscreenDropdown.ClearOptions(); // Очищаем опции в дропдауне режимов экрана
            List<string> fsmoptions = new List<string>(); // лист из строковых обозначений режимов экрана (пока пустой)
            fsmoptions.Add("Полноэкранный"); // добавляем в лист "Полноэкранный"
            fsmoptions.Add("Оконный"); // добавляем в лист "Оконный"
            fsmoptions.Add("Оконный без рамок"); // добавляем в лист "Оконный без рамок"
            fullscreenDropdown.AddOptions(fsmoptions); // добавляем в дропдаун опции выбора создающиеся с помощью строковых обозначений записанных в листе
            fullscreenDropdown.RefreshShownValue(); // перезагружаем картинку
            oldfullscreenModeIndex = 0; // для первого запуска чтобы был полноэкранный режим
            SetFullScreenMode(oldfullscreenModeIndex, fullscreenDropdown); // ставим режим экрана на 1(полноэкранный)


            resolutions = Screen.resolutions; // Записываем разрешения экрана игрока в массив
            resolutionDropdown.ClearOptions(); // очищаем разрешения которые были до этого момента в кнопке в настройках
            List<string> options = new List<string>(); // создаем лист строк для разрешений
            int currentResolutionIndex = 0; // текущее разрешение
            for (int i = 0; i < resolutions.Length; i++) // цикл по массиву разрешений игрока
            {
                string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "hz"; // создаем строковое наименование разрешения
                options.Add(option); // добавляем строковое наименование разрешения в лист

                if ((resolutions[i].width == Screen.currentResolution.width) && (resolutions[i].height == Screen.currentResolution.height))
                {
                    currentResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options); // добавляем в кнопку разрешения экрана игрока
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
            oldresolutionIndex = currentResolutionIndex;
            flag = false;
            SaveFlag();
            SaveSettings(oldvolume, oldqualityIndex, oldresolutionIndex, oldfullscreenModeIndex);
        }
        else 
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
            LoadSettings();
            
        }
    }

    public void SetVolume(float volume, Slider volumeS) // функция изменения звука
    {
        audioMixer.SetFloat("Volume",volume);
        volumeS.value = volume;
    }

    public void SetQuality(int qualityIndex,Dropdown qualityDd) // функция изменения качества
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityDd.value = qualityIndex;
    }

    public void SetFullScreenMode(int fullscreenmodeIndex, Dropdown fullscreenmodeDD) 
    {
        Screen.fullScreenMode = fullscreenmodes[fullscreenmodeIndex];
        fullscreenmodeDD.value = fullscreenmodeIndex;
    }
    

    public void SetResolution(int resolutionIndex,Dropdown resolutionDD) // функция смены разрешения
    {
        Resolution resolution = resolutions[resolutionIndex]; // для удобства создаем переменную разрешения в которую записываем то разрешение на которое меняем
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate); // меняем разрешение
        resolutionDD.value = resolutionIndex;
    }

    public void SaveFlag() 
    {
        int temp;
        if (flag)
           temp = 1;
        else
            temp = 0;
        PlayerPrefs.SetInt("Flag",temp);
    }

    public void LoadFlag() 
    {
        if (PlayerPrefs.GetInt("Flag", 4) != 4) 
        { 
        int temp = PlayerPrefs.GetInt("Flag");
        if (temp == 1)
            flag = true;
        else
            flag = false;
        }
    }
    public void SaveSettings(float v, int indq, int indr, int indf )
    {

        PlayerPrefs.SetInt("FullScreenMode", indf);
        PlayerPrefs.SetFloat("Volume",v);
        PlayerPrefs.SetInt("QualityIndex",indq);
        PlayerPrefs.SetInt("ResolutionIndex",indr);
        PlayerPrefs.Save();
    }

    public void LoadSettings() 
    {
        oldvolume = PlayerPrefs.GetFloat("Volume");
        oldfullscreenModeIndex = PlayerPrefs.GetInt("FullScreenMode");
        oldresolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        oldqualityIndex = PlayerPrefs.GetInt("QualityIndex");
        SetVolume(oldvolume, volumeSlider);
        SetQuality(oldqualityIndex, qualityDropdowm);
        SetFullScreenMode(oldfullscreenModeIndex, fullscreenDropdown);
        SetResolution(oldresolutionIndex, resolutionDropdown);
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

    public void CancelButton() 
    {
        SetVolume(oldvolume, volumeSlider);
        SetQuality(oldqualityIndex, qualityDropdowm);
        SetResolution(oldresolutionIndex, resolutionDropdown);
        SetFullScreenMode(oldfullscreenModeIndex, fullscreenDropdown);
    }

    public void DeleteSettingsButton() // удаление настроек с компа
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
