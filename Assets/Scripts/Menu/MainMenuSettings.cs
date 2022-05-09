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

    FullScreenMode[] fullscreenmodes;

    public Dropdown fullscreenDropdown;

    private int fullscreenModeIndex;

    private int oldfullscreenModeIndex;

    private int newfullscreenModeIndex;

    public Dropdown resolutionDropdown; //������ �� ���������� ������ ������ � ���� �������� � ������

    public Dropdown qualityDropdowm; // ������ �������� ������� � ���� �������� � ������

    public Slider volumeSlider; // ������� ����� � ���� ��������

    private float oldvolume; // �������� ��������� ���� ��� ������ ��������

    private int oldqualityIndex; // ������ ������� �������� ��� ������ ��������

    private int oldresolutionIndex; // ������ ���������� ��� ������ ��������

    private float newvolume; // �������� ��������� ���� ��� ����� ��������

    private int newqualityIndex; // ������ ������� �������� ��� ����� ��������

    private int newresolutionIndex; // ������ ���������� ��� ����� ��������

    private bool flag = true;

    void Start() 
    {
        LoadFlag();
        //������ ����� ����
        if (flag)
        {
            oldvolume = -60;
            SetVolume(oldvolume, volumeSlider);

            oldqualityIndex = 6;
            SetQuality(oldqualityIndex, qualityDropdowm);
            qualityDropdowm.value = oldqualityIndex;

            fullscreenmodes = new FullScreenMode[3]; // ������� ������ ������� ������
            fullscreenmodes[0] = FullScreenMode.ExclusiveFullScreen; // ��������� �������������
            fullscreenmodes[1] = FullScreenMode.Windowed; // ��������� �������
            fullscreenmodes[2] = FullScreenMode.FullScreenWindow; // ��������� ������� ��� �����
            fullscreenDropdown.ClearOptions(); // ������� ����� � ��������� ������� ������
            List<string> fsmoptions = new List<string>(); // ���� �� ��������� ����������� ������� ������ (���� ������)
            fsmoptions.Add("�������������"); // ��������� � ���� "�������������"
            fsmoptions.Add("�������"); // ��������� � ���� "�������"
            fsmoptions.Add("������� ��� �����"); // ��������� � ���� "������� ��� �����"
            fullscreenDropdown.AddOptions(fsmoptions); // ��������� � �������� ����� ������ ����������� � ������� ��������� ����������� ���������� � �����
            fullscreenDropdown.RefreshShownValue(); // ������������� ��������
            oldfullscreenModeIndex = 0; // ��� ������� ������� ����� ��� ������������� �����
            SetFullScreenMode(oldfullscreenModeIndex, fullscreenDropdown); // ������ ����� ������ �� 1(�������������)


            resolutions = Screen.resolutions; // ���������� ���������� ������ ������ � ������
            resolutionDropdown.ClearOptions(); // ������� ���������� ������� ���� �� ����� ������� � ������ � ����������
            List<string> options = new List<string>(); // ������� ���� ����� ��� ����������
            int currentResolutionIndex = 0; // ������� ����������
            for (int i = 0; i < resolutions.Length; i++) // ���� �� ������� ���������� ������
            {
                string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "hz"; // ������� ��������� ������������ ����������
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
            fsmoptions.Add("�������������");
            fsmoptions.Add("�������");
            fsmoptions.Add("������� ��� �����");
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

    public void SetVolume(float volume, Slider volumeS) // ������� ��������� �����
    {
        //audioMixer.SetFloat("Volume",volume);
        audioMixer.SetFloat("Volume",Mathf.Log10(volume) * 20);
        volumeS.value = volume;
    }

    public void SetQuality(int qualityIndex,Dropdown qualityDd) // ������� ��������� ��������
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityDd.value = qualityIndex;
    }

    public void SetFullScreenMode(int fullscreenmodeIndex, Dropdown fullscreenmodeDD) 
    {
        Screen.fullScreenMode = fullscreenmodes[fullscreenmodeIndex];
        fullscreenmodeDD.value = fullscreenmodeIndex;
    }
    

    public void SetResolution(int resolutionIndex,Dropdown resolutionDD) // ������� ����� ����������
    {
        Resolution resolution = resolutions[resolutionIndex]; // ��� �������� ������� ���������� ���������� � ������� ���������� �� ���������� �� ������� ������
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate); // ������ ����������
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
        //audioMixer.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
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

    public void DeleteSettingsButton() // �������� �������� � �����
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
