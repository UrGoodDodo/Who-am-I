using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    /*
    void Start()
    {
        resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        List<string> options = new List<string>(); //Создание списка со строковыми значениями

        for (int i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currResolutionIndex = i; //То получается его индекс
            }
        }

        resolutionDropdown.AddOptions(options); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }
    
    public bool isOpened = false; //Открыто ли меню
                                  // public float volume = 0; //Громкость
                                  // public int quality = 0; //Качество
    public bool isFullscreen = false; //Полноэкранный режим
                                      // public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

    
    
    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }
    



    
    public void ChangeQuality(int index) //Изменение качества
    {
        quality = index;
    }
    
    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
    }

    public void ChangeResolution(int index) //Изменение разрешения
    {
        currResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
    {
        isFullscreen = val;
    }

    public void SaveSettings()
    {
        //  audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
        // QualitySettings.SetQualityLevel(quality); //Изменение качества
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //Изменения разрешения
    }
    */

    public AudioMixer audioMixer; // Пока не знаю но вроде как звук в игре

    Resolution[] resolutions; // массив разрешений экрана игрока

    public Dropdown resolutionDropdown; //Список из разрешений экрана игрока в меню настроек в кнопке

    void Start() 
    {
        resolutions = Screen.resolutions; // Записываем разрешения экрана игрока в массив
        resolutionDropdown.ClearOptions(); // очищаем разрешения которые были до этого момента в кнопке в настройках
        List<string> options = new List<string>(); // создаем лист строк для разрешений
        int currentResolutionIndex = 0; // текущее разрешение
        for (int i = 0; i < resolutions.Length; i++) // цикл по массиву разрешений игрока
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; // создаем строковое наименование разрешения
            options.Add(option); // добавляем строковое наименование разрешения в лист

            if ((resolutions[i].width == Screen.currentResolution.width) && (resolutions[i].height == Screen.currentResolution.height))
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // добавляем в кнопку разрешения экрана игрока
        resolutionDropdown.value = currentResolutionIndex; 
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume) // функция изменения звука
    {
        audioMixer.SetFloat("Volume",volume);
    }

    public void SetQuality(int qualityIndex) // функция изменения качества
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool IsFullScreen) // функция изменения полноэкранного режима
    {
        Screen.fullScreen = IsFullScreen;
    }

    public void SetResolution(int resolutionIndex) // функция смены разрешения
    {
        Resolution resolution = resolutions[resolutionIndex]; // для удобства создаем переменную разрешения в которую записываем то разрешение на которое меняем
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // меняем разрешение
    }
}
