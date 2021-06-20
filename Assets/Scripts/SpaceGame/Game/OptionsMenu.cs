using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using TMPro;


public class OptionsMenu : MonoBehaviour
{

    #region SetResolution
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
     List<int> frameRate = new List<int>();
     List<string> frameRates = new List<string>();
    public TMP_Dropdown fpsDropdown;


    private void Start()
    {
        //Get monitor resolution
        resolutions = Screen.resolutions;
        //empty drop down
        resolutionDropdown.ClearOptions();
       

        //Create a list of string
        List<string> options = new List<string>();
        //Current Resolution Index
        int currentResolutionIndex = 0;
        //loop through and create option for the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fpsDropdown.ClearOptions();


        frameRate.Add(30);
        frameRate.Add(50);
        frameRate.Add(60);

       
        for (int i= 0; i < frameRate.Count; i++)
        {
            string newFPS = frameRate[i].ToString();
            frameRates.Add(newFPS + " FPS");
        }
        fpsDropdown.AddOptions(frameRates);
        fpsDropdown.RefreshShownValue();
    }
    /// <summary>
    /// Resolution Dropdown
    /// </summary>
    /// <param name="resolutionIndex"> the index of resolution setting within the dropdown </param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

    }
    #endregion
    /// <summary>
    /// Anti aliasing toggle
    /// </summary>
    /// <param name="active"> On and off setting for anti aliasing</param>
    public void AntiAliasing(bool active)
    {

        if (active)
        {
            QualitySettings.antiAliasing = 2;
        }
        else
        {
            QualitySettings.antiAliasing = 0;
        }
        
    }
    /// <summary>
    /// The frame rate set for the game
    /// </summary>
    /// <param name="fps"> The index in the dropdown </param>
    public void SetFrameRate(int fps)
    {
        Application.targetFrameRate = frameRate[fps];
       
    }
    /// <summary>
    /// The anistropic filering toggle
    /// </summary>
    /// <param name="active">  On and off setting for anisotropic filtering </param>
    public void SetAnisotropicFiltering(bool active)
    {
        if (active)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;

        }
        else
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;

        }

    }
}
