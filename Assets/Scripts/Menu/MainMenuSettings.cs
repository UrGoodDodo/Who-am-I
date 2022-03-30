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
        resolutionDropdown.ClearOptions(); //�������� ������ �������
        resolutions = Screen.resolutions; //��������� ��������� ����������
        List<string> options = new List<string>(); //�������� ������ �� ���������� ����������

        for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
            options.Add(option); //���������� ������ � ������

            if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
            {
                currResolutionIndex = i; //�� ���������� ��� ������
            }
        }

        resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
        resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
        resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }
    
    public bool isOpened = false; //������� �� ����
                                  // public float volume = 0; //���������
                                  // public int quality = 0; //��������
    public bool isFullscreen = false; //������������� �����
                                      // public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������
    private int currResolutionIndex = 0; //������� ����������

    
    
    public void ChangeVolume(float val) //��������� �����
    {
        volume = val;
    }
    



    
    public void ChangeQuality(int index) //��������� ��������
    {
        quality = index;
    }
    
    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; //��������� ��� ���������� Canvas. ��� ��� ����� ������������ ����� SetActive()
    }

    public void ChangeResolution(int index) //��������� ����������
    {
        currResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
    {
        isFullscreen = val;
    }

    public void SaveSettings()
    {
        //  audioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
        // QualitySettings.SetQualityLevel(quality); //��������� ��������
        Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
    }
    */

    public AudioMixer audioMixer; // ���� �� ���� �� ����� ��� ���� � ����

    Resolution[] resolutions; // ������ ���������� ������ ������

    public Dropdown resolutionDropdown; //������ �� ���������� ������ ������ � ���� �������� � ������

    void Start() 
    {
        resolutions = Screen.resolutions; // ���������� ���������� ������ ������ � ������
        resolutionDropdown.ClearOptions(); // ������� ���������� ������� ���� �� ����� ������� � ������ � ����������
        List<string> options = new List<string>(); // ������� ���� ����� ��� ����������
        int currentResolutionIndex = 0; // ������� ����������
        for (int i = 0; i < resolutions.Length; i++) // ���� �� ������� ���������� ������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; // ������� ��������� ������������ ����������
            options.Add(option); // ��������� ��������� ������������ ���������� � ����

            if ((resolutions[i].width == Screen.currentResolution.width) && (resolutions[i].height == Screen.currentResolution.height))
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // ��������� � ������ ���������� ������ ������
        resolutionDropdown.value = currentResolutionIndex; 
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume) // ������� ��������� �����
    {
        audioMixer.SetFloat("Volume",volume);
    }

    public void SetQuality(int qualityIndex) // ������� ��������� ��������
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool IsFullScreen) // ������� ��������� �������������� ������
    {
        Screen.fullScreen = IsFullScreen;
    }

    public void SetResolution(int resolutionIndex) // ������� ����� ����������
    {
        Resolution resolution = resolutions[resolutionIndex]; // ��� �������� ������� ���������� ���������� � ������� ���������� �� ���������� �� ������� ������
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // ������ ����������
    }
}
