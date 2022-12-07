using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropDown;
    public Toggle fullscreenBtn;
    public GameObject resolutionPanel;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;

    void Start()
    {
        IintUI();
    }

    void IintUI()
    {
        for(int i = 0; i < Screen.resolutions.Length; i+=100)
        {
            if(Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutions.AddRange(Screen.resolutions);
        resolutionDropDown.options.Clear();
        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + " X " + item.height + " " + item.refreshRate + "hz";
            resolutionDropDown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropDown.value = optionNum;
                optionNum++;
            }
        }
        resolutionDropDown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals
            (FullScreenMode.FullScreenWindow) ? true : false;
    }
    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void OnBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
        resolutionPanel.SetActive(false);
    }
    public void OpenresolutionPanel()
    {
        resolutionPanel.SetActive(true);
    }
}
