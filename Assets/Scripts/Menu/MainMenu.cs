using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню
   // public float volume = 0; //Громкость
   // public int quality = 0; //Качество
    public bool isFullscreen = false; //Полноэкранный режим
   // public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение


    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
    }

    /*
    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }
    */

    public void ChangeResolution(int index) //Изменение разрешения
    {
        currResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
    {
        isFullscreen = val;
    }

    /*
    public void ChangeQuality(int index) //Изменение качества
    {
        quality = index;
    }
    */

    public void SaveSettings()
    {
      //  audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
       // QualitySettings.SetQualityLevel(quality); //Изменение качества
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //Изменения разрешения
    }


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
    /*
    public void OpenScene(int index) // публичная функция загрузки сцены по индексу
    {
        SceneManager.LoadScene(index); // индекс сцены
    }
    */
    public void QuitGame()
    {
        Application.Quit();
    }
}
