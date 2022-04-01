using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{ 
    public AudioMixer audioMixer; // ���� �� ���� �� ����� ��� ���� � ����

    Resolution[] resolutions; // ������ ���������� ������ ������

    public Dropdown resolutionDropdown; //������ �� ���������� ������ ������ � ���� �������� � ������

    public Dropdown qualityDropdowm; // ������ �������� ������� � ���� �������� � ������

    public Toggle fullscreenToggle; // ���� ��� �������������� ������

    public Slider volumeSlider; // ������� ����� � ���� ��������

    private float oldvolume; // �������� ��������� ���� ��� ������ ��������

    private int oldqualityIndex; // ������ ������� �������� ��� ������ ��������

    private bool oldIsFullScreen; // ���� ���������� ��� �������������� ������ ��� ������ ��������

    private int oldresolutionIndex; // ������ ���������� ��� ������ ��������

    private float newvolume; // �������� ��������� ���� ��� ����� ��������

    private int newqualityIndex; // ������ ������� �������� ��� ����� ��������

    private bool newIsFullScreen; // ���� ���������� ��� �������������� ������ �� ����� ��������

    private int newresolutionIndex; // ������ ���������� ��� ����� ��������

    private bool flag = true;

    void Start() 
    {
        LoadFlag();
        //1 ����� ����
        if (flag)
        {
            oldvolume = -60;
            SetVolume(oldvolume, volumeSlider);

            oldqualityIndex = 6;
            SetQuality(oldqualityIndex, qualityDropdowm);
            qualityDropdowm.value = oldqualityIndex;

            oldIsFullScreen = true;
            SetFullScreen(oldIsFullScreen, fullscreenToggle);

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
            oldresolutionIndex = currentResolutionIndex;
            flag = false;
            SaveFlag();
        }
        else 
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            for (int i = 0; i < resolutions.Length; i++) 
            {
                string option = resolutions[i].width + " x " + resolutions[i].height; 
                options.Add(option); 
            }
            resolutionDropdown.AddOptions(options); 
            LoadSettings();
            
        }
    }

    public void SetVolume(float volume, Slider volumeS) // ������� ��������� �����
    {
        audioMixer.SetFloat("Volume",volume);
        volumeS.value = volume;
    }

    public void SetQuality(int qualityIndex,Dropdown qualityDd) // ������� ��������� ��������
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityDd.value = qualityIndex;
    }

    public void SetFullScreen(bool IsFullScreen, Toggle fullscreenT) // ������� ��������� �������������� ������
    {
        Screen.fullScreen = IsFullScreen;
        fullscreenT.isOn = IsFullScreen;
    }

    public void SetResolution(int resolutionIndex,Dropdown resolutionDD) // ������� ����� ����������
    {
        Resolution resolution = resolutions[resolutionIndex]; // ��� �������� ������� ���������� ���������� � ������� ���������� �� ���������� �� ������� ������
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // ������ ����������
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
    public void SaveSettings(float v, int indq, int indr, bool isfull) 
    {
        int isfullsreen;
        if (isfull)
            isfullsreen = 1;
        else
            isfullsreen = 0;
        
        PlayerPrefs.SetInt("IsFullScreen", isfullsreen);
        PlayerPrefs.SetFloat("Volume",v);
        PlayerPrefs.SetInt("QualityIndex",indq);
        PlayerPrefs.SetInt("ResolutionIndex",indr);
        PlayerPrefs.Save();
    }

    public void LoadSettings() 
    {
        oldvolume = PlayerPrefs.GetFloat("Volume");
        int temp = PlayerPrefs.GetInt("IsFullScreen");
        if (temp == 1)
            oldIsFullScreen = true;
        else
            oldIsFullScreen = false;
        oldresolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        oldqualityIndex = PlayerPrefs.GetInt("QualityIndex");
        SetVolume(oldvolume, volumeSlider);
        SetQuality(oldqualityIndex, qualityDropdowm);
        SetFullScreen(oldIsFullScreen, fullscreenToggle);
        SetResolution(oldresolutionIndex, resolutionDropdown);
    }

    public void SetNewResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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

    public void SetNewIsFullScreen(bool IsFullScreen) 
    {
        Screen.fullScreen = IsFullScreen;
        newIsFullScreen = IsFullScreen;
    }
    public void SaveButton() 
    {
        oldIsFullScreen = newIsFullScreen;
        oldqualityIndex = newqualityIndex;
        oldresolutionIndex = newresolutionIndex;
        oldvolume = newvolume;
        SaveSettings(oldvolume, oldqualityIndex, oldresolutionIndex, oldIsFullScreen);
    }

    public void CancelButton() 
    {
        SetVolume(oldvolume, volumeSlider);
        SetQuality(oldqualityIndex, qualityDropdowm);
        SetResolution(oldresolutionIndex, resolutionDropdown);
        SetFullScreen(oldIsFullScreen, fullscreenToggle);
    }
}
